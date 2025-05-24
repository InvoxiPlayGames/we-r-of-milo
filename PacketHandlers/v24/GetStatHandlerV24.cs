using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class GetStatHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public GetStatHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string path = stream.ReadLengthPrefixedString(Encoding.UTF8);
            Console.WriteLine(" path: " + path);

            stream.WriteByte((byte)HolmesPacketsV24.kGetStat);

            FileInfo? fi = FileManager.GetFileStat(path);
            if (fi != null && fi.Exists)
            {
                stream.WriteByte(1); // success
                stream.WriteInt32LE(0); // st_mode
                stream.WriteInt32LE((int)fi.Length); // st_size
                stream.WriteInt64LE(1000); // st_ctime
                stream.WriteInt64LE(1000); // st_atime
                stream.WriteInt64LE(1000); // st_mtime
            } else
            {
                stream.WriteByte(0); // failed
            }

        }
    }
}

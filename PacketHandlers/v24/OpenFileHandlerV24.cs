using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class OpenFileHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public OpenFileHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string filePath = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte flag1set = stream.ReadUInt8();
            byte flag18set = stream.ReadUInt8();
            byte flag9set = 0;
            byte flag11set = 0;
            if (flag1set == 0)
            {
                flag9set = stream.ReadUInt8();
                flag11set = stream.ReadUInt8();
            }
            Console.WriteLine(" file: {0}", filePath);
            Console.WriteLine(" flags: 1:{0} 18:{1} 9:{2} 11:{3}", flag1set, flag18set, flag9set, flag11set);

            int res = -1;
            int fd = FileManager.OpenFileReadOnly(filePath);
            if (fd != -1)
            {
                res = (int)FileManager.GetFile(fd)!.Length;
                Console.WriteLine(" opened with fd: {0}, length: {1}", fd, res);
            }

            stream.WriteByte((byte)HolmesPacketsV24.kOpenFile);
            stream.WriteInt32LE(res);
            if (fd != -1)
                stream.WriteInt32LE(fd);
        }
    }
}

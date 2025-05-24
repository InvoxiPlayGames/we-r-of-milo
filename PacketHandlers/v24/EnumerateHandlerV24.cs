using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class EnumerateHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public EnumerateHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string dir = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte unk1 = stream.ReadUInt8();
            string match = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte unk2 = stream.ReadUInt8();

            Console.WriteLine(" dir: " + dir);
            Console.WriteLine(" match: " + dir);
            Console.WriteLine(" unk1:" + unk1.ToString("X2") + " unk2:" + unk2.ToString("X2"));

            // stubbed response for now
            stream.WriteByte((byte)HolmesPacketsV24.kEnumerate);
            stream.WriteByte(0);
        }
    }
}

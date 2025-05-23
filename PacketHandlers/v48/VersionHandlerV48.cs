using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v48
{
    internal class VersionHandlerV48 : IPacketHandler
    {
        enum HxPlatform
        {
            kPlatformNone = 0,
        }

        public ConnectedClient Client { get; set; }
        public VersionHandlerV48(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            // todo: verify
            string hostName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string holmesTarget = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string shareName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string fsRoot = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string type = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte platform = stream.ReadUInt8();
            byte rndApi = stream.ReadUInt8();
            Console.WriteLine(" hostName: " + hostName);
            Console.WriteLine(" holmesTarget: " + holmesTarget);
            Console.WriteLine(" shareName: " + shareName);
            Console.WriteLine(" fsRoot: " + fsRoot);
            Console.WriteLine(" type: " + type);
            Console.WriteLine(" platform: 0x" + platform.ToString("X2"));
            Console.WriteLine(" rndApi: 0x" + rndApi.ToString("X2"));
            // write an error back for now
            stream.WriteByte((byte)HolmesPacketsV48.kVersion);
            stream.WriteInt32LE(-1);
        }
    }
}

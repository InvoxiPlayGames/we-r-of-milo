using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class VersionHandlerV24 : IPacketHandler
    {
        enum Platform
        {
            kPlatformNone = 0,
            kPlatformXbox = 2,
            kPlatformPC = 3,
            kPlatformPS3 = 4,
            kPlatformWii = 5
        }

        public ConnectedClient Client { get; set; }
        public VersionHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string hostName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string holmesTarget = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string shareName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string fsRoot = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte platform = stream.ReadUInt8();
            byte gfxMode = stream.ReadUInt8();
            Console.WriteLine(" hostName: " + hostName);
            Console.WriteLine(" holmesTarget: " + holmesTarget);
            Console.WriteLine(" shareName: " + shareName);
            Console.WriteLine(" fsRoot: " + fsRoot);
            Console.WriteLine(" platform: 0x" + platform.ToString("X2"));
            Console.WriteLine(" gfxMode: 0x" + gfxMode.ToString("X2"));

            stream.WriteByte((byte)HolmesPacketsV24.kVersion);
            stream.WriteInt32LE(24); // v24
            stream.WriteLengthPrefixedString(Encoding.UTF8, "serverName"); // serverName
            stream.WriteLengthPrefixedString(Encoding.UTF8, "."); // fileRoot
        }
    }
}

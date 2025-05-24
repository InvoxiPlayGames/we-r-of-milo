using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v63
{
    internal class VersionHandlerV63 : IPacketHandler
    {
        enum HxPlatform
        {
            kPlatformNone = 0,
        }

        public ConnectedClient Client { get; set; }
        public VersionHandlerV63(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            // todo: verify
            string hmxBranchIdentifier = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string holmesTarget = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string packageName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            string hmxProjectName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            byte platform = stream.ReadUInt8();
            byte rndApi = stream.ReadUInt8();
            Console.WriteLine(" hmxBranchIdentifier: " + hmxBranchIdentifier);
            Console.WriteLine(" holmesTarget: " + holmesTarget);
            Console.WriteLine(" packageName: " + packageName);
            Console.WriteLine(" hmxProjectName: " + hmxProjectName);
            Console.WriteLine(" platform: 0x" + platform.ToString("X2"));
            Console.WriteLine(" rndApi: 0x" + rndApi.ToString("X2"));
            // write an error back for now
            stream.WriteByte((byte)HolmesPacketsV63.kVersion);
            stream.WriteInt32LE(63);
            stream.WriteLengthPrefixedString(Encoding.UTF8, hmxBranchIdentifier);
            stream.WriteLengthPrefixedString(Encoding.UTF8, hmxProjectName);
            stream.WriteLengthPrefixedString(Encoding.UTF8, "we-r-of-milo"); // serverName
            stream.WriteLengthPrefixedString(Encoding.UTF8, "we-r-of-fileroot"); // fileRoot
        }
    }
}

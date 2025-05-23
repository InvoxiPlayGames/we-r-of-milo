using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class StackTraceHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public StackTraceHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string mapFile = stream.ReadLengthPrefixedString(Encoding.UTF8);
            Console.WriteLine(" mapFile: " + mapFile);
            int numStack = stream.ReadInt32LE();
            for (int i = 0; i < numStack; i++)
            {
                uint addr = stream.ReadUInt32LE();
                Console.WriteLine(" - 0x{0}", addr.ToString("X8"));
            }
            stream.WriteByte((byte)HolmesPacketsV24.kStackTrace);
            // passing a blank stack trace allows the game to report it itself
            // but this string actually lets you provide any arbitrary info to display on-screen and in logs
            stream.WriteLengthPrefixedString(Encoding.UTF8, "");
        }
    }
}

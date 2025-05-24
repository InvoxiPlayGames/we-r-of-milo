using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v63
{
    internal class StackTraceHandlerV63 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public StackTraceHandlerV63(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string mapFile = stream.ReadLengthPrefixedString(Encoding.UTF8);
            ulong refAddress = stream.ReadUInt64LE();
            Console.WriteLine(" mapFile: " + mapFile);
            Console.WriteLine(" refAddress: " + refAddress.ToString("X16"));
            int numStack = stream.ReadInt32LE();
            for (int i = 0; i < numStack; i++)
            {
                ulong addr = stream.ReadUInt64LE();
                string module = stream.ReadLengthPrefixedString(Encoding.UTF8);
                Console.WriteLine(" - {0}: 0x{1}", module, addr.ToString("X16"));
            }
            stream.WriteByte((byte)HolmesPacketsV24.kStackTrace);
            // passing a blank stack trace allows the game to report it itself
            // but this string actually lets you provide any arbitrary info to display on-screen and in logs
            stream.WriteLengthPrefixedString(Encoding.UTF8, "");
        }
    }
}

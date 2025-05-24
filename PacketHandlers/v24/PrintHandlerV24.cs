using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class PrintHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public PrintHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            string line = stream.ReadLengthPrefixedString(Encoding.UTF8);
            Console.WriteLine("--");
            Console.WriteLine(line);
            Console.WriteLine("--");
            Client._activePrintCount++;
            if (Client._activePrintCount > 2)
            {
                stream.WriteByte((byte)HolmesPacketsV24.kPrint);
                stream.WriteByte((byte)0);
                Client._activePrintCount--;
            }
        }
    }
}

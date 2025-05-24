using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class CacheResourceHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public CacheResourceHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }
        public void HandlePacket(Stream stream)
        {
            string resourceName = stream.ReadLengthPrefixedString(Encoding.UTF8);
            Console.WriteLine(" resourceName: " + resourceName);

            stream.WriteByte((byte)HolmesPacketsV24.kCacheResource);
            stream.WriteByte((byte)0); // success
        }
    }
}

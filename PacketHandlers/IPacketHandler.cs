using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers
{
    internal interface IPacketHandler
    {
        public ConnectedClient Client { get; set; }

        public void HandlePacket(Stream stream);
    }
}

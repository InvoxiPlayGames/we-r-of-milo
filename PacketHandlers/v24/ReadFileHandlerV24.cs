using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo.PacketHandlers.v24
{
    internal class ReadFileHandlerV24 : IPacketHandler
    {
        public ConnectedClient Client { get; set; }
        public ReadFileHandlerV24(ConnectedClient _client)
        {
            Client = _client;
        }

        public void HandlePacket(Stream stream)
        {
            int fd = stream.ReadInt32LE();
            int offset = stream.ReadInt32LE();
            int length = stream.ReadInt32LE();

            FileStream? file = FileManager.GetFile(fd);
            if (file == null)
            {
                Console.WriteLine("!! Client passed a bad fd!");
                Client.Disconnect();
                return;
            }
            file.Position = offset;
            byte[] readBytes = new byte[length];
            int numRead = file.Read(readBytes);

            stream.WriteByte((byte)HolmesPacketsV24.kReadFile);
            stream.Write(readBytes, 0, numRead);
        }
    }
}

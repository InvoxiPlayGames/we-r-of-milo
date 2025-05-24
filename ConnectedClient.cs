using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using we_r_of_milo.PacketHandlers;
using we_r_of_milo.PacketHandlers.v15;
using we_r_of_milo.PacketHandlers.v24;
using we_r_of_milo.PacketHandlers.v48;
using we_r_of_milo.PacketHandlers.v63;

namespace we_r_of_milo
{
    internal class ConnectedClient
    {
        public string _clientName;
        public bool _hasInit = false;
        public DateTime _lastPacket;
        public TcpClient _client;
        public HolmesVersion _version = HolmesVersion.kHolmesUnknown;
        public Dictionary<int, IPacketHandler> handlers = new Dictionary<int, IPacketHandler>();

        public ConnectedClient(TcpClient client) {
            _client = client;
            _clientName = client.Client.RemoteEndPoint!.ToString()!;
            _lastPacket = DateTime.Now;
        }

        private void ReadPacket()
        {
            NetworkStream str = _client.GetStream();
            int packetType = str.ReadByte();
            // first packet on version connections
            if (packetType == 0)
            {
                int packetVersion = str.ReadInt32LE();
                if (packetVersion == 15)
                {
                    Console.WriteLine("Client is v15!");
                    _version = HolmesVersion.kHolmesVer15;
                    RegisterHandlersV15();
                }
                else if (packetVersion == 24)
                {
                    Console.WriteLine("Client is v24!");
                    _version = HolmesVersion.kHolmesVer24;
                    RegisterHandlersV24();
                }
                else if (packetVersion == 48)
                {
                    Console.WriteLine("Client is v48!");
                    _version = HolmesVersion.kHolmesVer48;
                    RegisterHandlersV48();
                }
                else if (packetVersion == 63)
                {
                    Console.WriteLine("Client is v63!");
                    _version = HolmesVersion.kHolmesVer63;
                    RegisterHandlersV63();
                }
            }
            // print out what packet we got for what versionif (_version == HolmesVersion.kHolmesVer48)
            if (_version == HolmesVersion.kHolmesVer15)
            {
                HolmesPacketsV15 packet = (HolmesPacketsV15)packetType;
                Console.WriteLine("Handling {0} for {1} ({2})", packet, _clientName, _version);
            }
            else if (_version == HolmesVersion.kHolmesVer24)
            {
                HolmesPacketsV24 packet = (HolmesPacketsV24)packetType;
                Console.WriteLine("Handling {0} for {1} ({2})", packet, _clientName, _version);
            }
            else if (_version == HolmesVersion.kHolmesVer48)
            {
                HolmesPacketsV48 packet = (HolmesPacketsV48)packetType;
                Console.WriteLine("Handling {0} for {1} ({2})", packet, _clientName, _version);
            }
            else if (_version == HolmesVersion.kHolmesVer63)
            {
                HolmesPacketsV63 packet = (HolmesPacketsV63)packetType;
                Console.WriteLine("Handling {0} for {1} ({2})", packet, _clientName, _version);
            } else
            {
                Console.WriteLine("Unknown packet type {0} for unregistered client {1}", packetType.ToString("X2"), _clientName);
            }
            _lastPacket = DateTime.Now;
            // handle the packet
            if (handlers.ContainsKey(packetType))
                handlers[packetType].HandlePacket(str);
            else {
                Console.WriteLine(" ! No handler for this packet! Client is about to go crazy-go-nuts!");
                Disconnect();
            }
        }

        private void RegisterHandlersV15()
        {
            handlers[(int)HolmesPacketsV15.kVersion] = new VersionHandlerV15(this);
        }

        private void RegisterHandlersV24()
        {
            handlers[(int)HolmesPacketsV24.kVersion] = new VersionHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kOpenFile] = new OpenFileHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kReadFile] = new ReadFileHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kCloseFile] = new CloseFileHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kPrint] = new PrintHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kCacheResource] = new CacheResourceHandlerV24(this);
            handlers[(int)HolmesPacketsV24.kStackTrace] = new StackTraceHandlerV24(this);
        }

        private void RegisterHandlersV48()
        {
            handlers[(int)HolmesPacketsV48.kVersion] = new VersionHandlerV48(this);
        }

        private void RegisterHandlersV63()
        {
            handlers[(int)HolmesPacketsV63.kVersion] = new VersionHandlerV63(this);
            handlers[(int)HolmesPacketsV63.kStackTrace] = new StackTraceHandlerV63(this);
        }

        public void Disconnect() {
            _client.Close();
        }

        public bool Poll() {
            if (!_client.Connected)
                return false;
            if (_client.Available >= 1)
                ReadPacket();
            return true;
        }
    }
}

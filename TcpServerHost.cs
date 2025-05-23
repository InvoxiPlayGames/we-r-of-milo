using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo
{
    internal class TcpServerHost
    {
        TcpListener _listener;
        List<ConnectedClient> _clients;
        bool _started = false;

        public TcpServerHost(ushort port) {
            _listener = new TcpListener(IPAddress.Any, port);
            _clients = new List<ConnectedClient>();
        }

        public void Start() {
            _listener.Start();
            _started = true;
        }

        public void PrintClients()
        {
            foreach (var client in _clients)
            {
                Console.WriteLine(" - {0} ({1}): {2}", client._clientName, client._version, client._lastPacket);
            }
        }

        public void Poll() {
            if (!_started)
                return;
            if (_listener.Pending())
            {
                TcpClient newClient = _listener.AcceptTcpClient();
                ConnectedClient conn = new ConnectedClient(newClient);
                _clients.Add(conn);
                Console.WriteLine("Connected to " + conn._clientName);
            }
            foreach (var conn in _clients)
            {
                if (!conn.Poll())
                {
                    //somehow remove the client
                }
            }
        }

        public void Stop() {
            _started = false;
            _listener.Stop();
            foreach (var conn in _clients)
            {
                conn.Disconnect();
            }
            _clients.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using HeptagramServer;

namespace HeptagramServerExecutiveEnvironment
{
    class ExecutiveServer
    {
        TcpListener serverListener;
        string hostname;
        IPAddress serverIP;
        int port;
        bool _isTerminated = false;
        Dictionary<Guid, Peer> peerDictionary;

        public bool isTerminated
        {
            get
            {
                return _isTerminated;
            }
        }

        public ExecutiveServer(int port)
        {
            this.port = port;
            hostname = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostEntry(hostname).AddressList;
            for(int i = 0; i<ips.Length;i++)
            {
                if(ips[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIP = ips[i];
                    break;
                }
            }
            peerDictionary = new Dictionary<Guid, Peer>();
            IPEndPoint endPoint = new IPEndPoint(serverIP, port);
            serverListener = new TcpListener(endPoint);
            serverListener.Start(100);
            Task ConnectionAcceptTask = new Task(ConnectionAccepter);
            Console.WriteLine("server start");
            Console.WriteLine("IP: {0}",serverIP);
            ConnectionAcceptTask.Start();
        }

        private void ConnectionAccepter()
        {
            while (true)
            {
                Console.WriteLine("Wait for a peer");
                Guid guid = Guid.NewGuid();
                Peer peer = new Peer(guid, serverListener.AcceptSocket());
                peerDictionary.Add(peer.guid, peer);
            }
        }
    }
}

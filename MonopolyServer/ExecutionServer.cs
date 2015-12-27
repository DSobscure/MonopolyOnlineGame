using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MonopolyServer
{
    class ExecutionServer
    {
        string hostname;
        int port;
        IPAddress serverIP;
        bool isTerminated;
        TcpListener serverListener;
        Dictionary<Guid, PeerBase> peerDictionary;
        Server server;

        public ExecutionServer(int port)
        {
            this.port = port;
            hostname = Dns.GetHostName();
            serverIP = Dns.GetHostEntry(hostname).AddressList.First(x=>x.AddressFamily == AddressFamily.InterNetwork);
            server = new Server();
            server.logger.Info(serverIP.ToString());
            isTerminated = false;
            serverListener = new TcpListener(serverIP, port);
            peerDictionary = new Dictionary<Guid, PeerBase>();
            AcceptConnection();
        }

        void AcceptConnection()
        {
            serverListener.Start();
            server.logger.Info("Waiting for connection ....");
            while (!isTerminated)
            {
                TcpClient client = serverListener.AcceptTcpClient();
                server.logger.Info(string.Format("Accept connectiion from {0} : {1}", (client.Client.LocalEndPoint as IPEndPoint).Address, (client.Client.LocalEndPoint as IPEndPoint).Port));
                Guid newGuid = Guid.NewGuid();
                peerDictionary.Add(newGuid, new Peer(newGuid, client, server));
                Thread.Sleep(1);
            }
        }
    }
}

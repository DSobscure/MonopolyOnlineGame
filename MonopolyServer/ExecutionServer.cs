using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MonopolyServer
{
    public class ExecutionServer
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
            //foreach (IPAddress ip in Dns.GetHostEntry(hostname).AddressList)
            //{
            //    Console.WriteLine(ip);
            //}
            //Console.WriteLine("Input the IP:");
            //serverIP = IPAddress.Parse(Console.ReadLine());
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
                server.logger.Info(string.Format("Accept connectiion from {0} : {1}", (client.Client.RemoteEndPoint as IPEndPoint).Address, (client.Client.RemoteEndPoint as IPEndPoint).Port));
                Guid newGuid = Guid.NewGuid();
                Peer peer = new Peer(newGuid, client, server);
                peer.OnPeerDisconnect += PeerDisconnect;
                peerDictionary.Add(newGuid, peer);
                Thread.Sleep(1);
            }
        }

        void PeerDisconnect(Guid guid)
        {
            if(peerDictionary.ContainsKey(guid))
                peerDictionary.Remove(guid);
        }
    }
}

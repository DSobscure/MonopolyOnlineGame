using OnlineGameDataStructure;
using System;
using System.Net.Sockets;

namespace MonopolyServer
{
    class Peer
    {
        Guid guid;
        TcpClient tcpClient;
        Server server;
        User user;

        public Peer(Guid guid, TcpClient tcpClient, Server server)
        {
            this.guid = guid;
            this.tcpClient = tcpClient;
            this.server = server;
        }

        void OnDisconnect()
        {

        }

        void OnOperationRequest()
        {

        }
    }
}

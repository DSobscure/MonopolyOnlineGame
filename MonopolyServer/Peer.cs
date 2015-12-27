using MonopolyProtocol;
using OnlineGameDataStructure;
using System;
using System.Net.Sockets;

namespace MonopolyServer
{
    class Peer : PeerBase
    {
        User user;

        public Peer(Guid guid, TcpClient tcpClient, Server server) : base(guid, tcpClient, server)
        {
            
        }

        protected override void OnDisconnect()
        {
            server.logger.Info(guid.ToString() + " : " + "Disconnect");
        }

        protected override void OnOperationRequest(OperationRequest operationRequest)
        {
            server.logger.Info(guid.ToString() + " : " + operationRequest.OperationCode);
        }
    }
}

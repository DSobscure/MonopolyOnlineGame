using MonopolyProtocol;
using OnlineGameDataStructure;
using System;
using System.Net.Sockets;

namespace MonopolyServer
{
    partial class Peer : PeerBase
    {
        public event Action<Guid> OnPeerDisconnect;
        ServerUser user;

        public Peer(Guid guid, TcpClient tcpClient, Server server) : base(guid, tcpClient, server)
        {
            
        }

        protected override void OnDisconnect()
        {
            server.UserOffline(user);
            OnPeerDisconnect?.Invoke(guid);
            server.logger.Info(guid.ToString() + " : " + "Disconnect");
        }

        protected override void OnOperationRequest(OperationRequest operationRequest)
        {
            server.logger.Info(guid.ToString() + " : " + (OperationType)operationRequest.OperationCode);
            switch(operationRequest.OperationCode)
            {
                #region login
                case (byte)OperationType.Login:
                    {
                        LoginTask(operationRequest);
                    }
                    break;
                #endregion
            }
        }
    }
}

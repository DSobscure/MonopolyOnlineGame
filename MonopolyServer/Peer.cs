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
            if(user != null)
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

                #region get lobby data
                case (byte)OperationType.GetLobbyData:
                    {
                        GetLobbyDataTask(operationRequest);
                    }
                    break;
                #endregion

                #region send message
                case (byte)OperationType.SendMessage:
                    {
                        SendMessageTask(operationRequest);
                    }
                    break;
                #endregion

                #region create room
                case (byte)OperationType.CreateRoom:
                    {
                        CreateRoomTask(operationRequest);
                    }
                    break;
                #endregion

                #region join room
                case (byte)OperationType.JoinRoom:
                    {
                        JoinRoomTask(operationRequest);
                    }
                    break;
                #endregion

                #region ready for game
                case (byte)OperationType.ReadyForGame:
                    {
                        ReadyForGameTask(operationRequest);
                    }
                    break;
                #endregion

                #region cancle ready
                case (byte)OperationType.CancleReady:
                    {
                        CancleReadyTask(operationRequest);
                    }
                    break;
                #endregion

                #region start game
                case (byte)OperationType.StartGame:
                    {
                        StartGameTask(operationRequest);
                    }
                    break;
                #endregion

                #region exit game
                case (byte)OperationType.ExitGame:
                    {
                        ExitGameTask(operationRequest);
                    }
                    break;
                #endregion

                #region close room
                case (byte)OperationType.CloseRoom:
                    {
                        CloseRoomTask(operationRequest);
                    }
                    break;
                #endregion

                #region get game data
                case (byte)OperationType.GetGameData:
                    {
                        GetGameDataTask(operationRequest);
                    }
                    break;
                #endregion

                #region roll dice
                case (byte)OperationType.RollDice:
                    {
                        RollDiceTask(operationRequest);
                    }
                    break;
                #endregion

                #region buy land
                case (byte)OperationType.BuyLand:
                    {
                        BuyLandTask(operationRequest);
                    }
                    break;
                #endregion

                #region upgrade land
                case (byte)OperationType.UpgradeLand:
                    {
                        UpgradeLandTask(operationRequest);
                    }
                    break;
                #endregion

                #region get player data
                case (byte)OperationType.GetPlayerData:
                    {
                        GetPlayerDataTask(operationRequest);
                    }
                    break;
                #endregion

                #region give up
                case (byte)OperationType.GiveUp:
                    {
                        GiveUpTask(operationRequest);
                    }
                    break;
                #endregion
            }
        }
    }
}

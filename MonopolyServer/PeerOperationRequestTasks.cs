using MonopolyProtocol;
using Newtonsoft.Json;
using OnlineGameDataStructure;
using System.Collections.Generic;
using System.Linq;
using MonopolyGame;

namespace MonopolyServer
{
    partial class Peer : PeerBase
    {
        private void LoginTask(OperationRequest operationRequest)
        {
            if (operationRequest.Parameters.Count != 1)
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidParameter,
                        "LoginTask Parameter Error",
                        new Dictionary<byte, object>()
                    );
                server.logger.Info(string.Format("{0} LoginTask Parameter Error", guid));
                SendResponse(response);
            }
            else
            {
                string userName = (string)operationRequest.Parameters[(byte)LoginParameterItem.UserName];
                if(server.UserOnline(user = new ServerUser(userName, false, this)))
                {
                    LobbyUpdateBroadcast(server.lobby);
                    Dictionary<byte, object> parameter = new Dictionary<byte, object>
                    {
                        { (byte)LoginResponseItem.UserName, user.userName }
                    };
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        parameter
                    );
                    server.logger.Info(string.Format("{0} 登入成功", user.userName));
                    SendResponse(response);
                }
                else
                {
                    OperationResponse response = new OperationResponse
                        (
                            operationRequest.OperationCode,
                            (byte)ReturnCode.InvalidOperation,
                            "此帳號已經登入!",
                            new Dictionary<byte, object>()
                        );
                    server.logger.Info(string.Format("{0} 此帳號已經登入", guid));
                    SendResponse(response);
                }
            }
        }
        private void GetLobbyDataTask(OperationRequest operationRequest)
        {
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                { (byte)GetLobbyDataResponseItem.LobbyDataString, JsonConvert.SerializeObject(server.lobby.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
            };
            OperationResponse response = new OperationResponse
                        (
                            operationRequest.OperationCode,
                            (byte)ReturnCode.Correct,
                            "",
                            parameter
                        );
            server.logger.Info(string.Format("{0} 取得了大廳資料", user.userName));
            SendResponse(response);
        }
        private void SendMessageTask(OperationRequest operationRequest)
        {
            if (operationRequest.Parameters.Count != 1)
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidParameter,
                        "SendMessageTask Parameter Error",
                        new Dictionary<byte, object>()
                    );
                SendResponse(response);
            }
            else
            {
                string message = (string)operationRequest.Parameters[(byte)SendMessageParameterItem.Message];

                if (SendMessageBroadcast(message))
                {
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
                    SendResponse(response);
                }
                else
                {
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.NotExist,
                        "Send target not exist",
                        new Dictionary<byte, object>()
                    );
                    SendResponse(response);
                }
            }
        }
        private void CreateRoomTask(OperationRequest operationRequest)
        {
            if (operationRequest.Parameters.Count != 3)
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidParameter,
                        "CreateRoomTask Parameter Error",
                        new Dictionary<byte, object>()
                    );
                SendResponse(response);
            }
            else
            {
                string roomName = (string)operationRequest.Parameters[(byte)CreateRoomParameterItem.RoomName];
                bool isEncrypted = (bool)operationRequest.Parameters[(byte)CreateRoomParameterItem.IsEncrypted];
                string password = (string)operationRequest.Parameters[(byte)CreateRoomParameterItem.Password];
                Room room;

                if (CreateRoom(roomName, isEncrypted, password, out room))
                {
                    Dictionary<byte, object> parameter = new Dictionary<byte, object>
                    {
                        { (byte)CreateRoomResponseItem.RoomDataString, JsonConvert.SerializeObject(room.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                    };
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        parameter
                    );
                    SendResponse(response);
                }
                else
                {
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidOperation,
                        "建立房間失敗",
                        new Dictionary<byte, object>()
                    );
                    SendResponse(response);
                }
            }
        }
        private void JoinRoomTask(OperationRequest operationRequest)
        {
            if (operationRequest.Parameters.Count != 2)
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidParameter,
                        "JoinRoomTask Parameter Error",
                        new Dictionary<byte, object>()
                    );
                SendResponse(response);
            }
            else
            {
                int roomID = (int)(long)operationRequest.Parameters[(byte)JoinRoomParameterItem.RoomID];
                string password = (string)operationRequest.Parameters[(byte)JoinRoomParameterItem.Password];
                Room room;

                if (JoinRoom(roomID, password, out room))
                {
                    Dictionary<byte, object> parameter = new Dictionary<byte, object>
                    {
                        { (byte)JoinRoomResponseItem.RoomDataString, JsonConvert.SerializeObject(room?.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                    };
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        parameter
                    );
                    SendResponse(response);
                }
                else
                {
                    OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.InvalidOperation,
                        "加入房間失敗",
                        new Dictionary<byte, object>()
                    );
                    SendResponse(response);
                }
            }
        }
        private void ReadyForGameTask(OperationRequest operationRequest)
        {
            user.ready = true;
            OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
            SendResponse(response);
            RoomUpdateBroadcast(user.userGroup as Room);
        }
        private void CancleReadyTask(OperationRequest operationRequest)
        {
            user.ready = false;
            OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
            SendResponse(response);
            RoomUpdateBroadcast(user.userGroup as Room);
        }
        private void StartGameTask(OperationRequest operationRequest)
        {
            if(/*!(user.userGroup as Room).users.Any(x=>x.Value.ready) && */server.CreateGame(user.userGroup.users.Values.ToList()))
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
                SendResponse(response);
            }
            else
            {
                OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.PermissionDeny,
                        "開始遊戲錯誤",
                        new Dictionary<byte, object>()
                    );
                SendResponse(response);
            }
        }
        private void ExitRoomTask(OperationRequest operationRequest)
        {
            ExitRoom();
            OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
            SendResponse(response);
        }
        private void GetGameDataTask(OperationRequest operationRequest)
        {

        }
        private void RollDiceTask(OperationRequest operationRequest)
        {
            int result = user.playingGame.RollDice();
            OperationResponse response = new OperationResponse
                    (
                        operationRequest.OperationCode,
                        (byte)ReturnCode.Correct,
                        "",
                        new Dictionary<byte, object>()
                    );
            SendResponse(response);
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                {(byte)RollDiceResultParameterItem.DiceNumber, result}
            };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in (user.playingGame as ServerGame).users)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.RollDiceResult, parameter);
            user.playingGame.players[user.playingGame.turnCounter% user.playingGame.players.Count].Move(result);
            GameUpdateBroadcast(user.playingGame);
        }
        private void BuyLandTask(OperationRequest operationRequest)
        {
            (user.playingGame.map.blocks[user.player.token.position] as LandBlock).land.Buy(user.player);
            if(user.player.money >= 0)
            {
                Dictionary<byte, object> parameter = new Dictionary<byte, object>
                {
                    {(byte)BuyLandBroadcastParameterItem.PlayerName, user.player.username},
                    {(byte)BuyLandBroadcastParameterItem.LandName, (user.playingGame.map.blocks[user.player.token.position] as LandBlock).land.name}
                };
                List<Peer> peers = new List<Peer>();
                foreach (ServerUser targetUser in (user.playingGame as ServerGame).users)
                {
                    peers.Add(targetUser.Peer);
                }
                server.Broadcast(peers.ToArray(), BroadcastType.BuyLand, parameter);
            }
            if(user.playingGame != null)
                GameUpdateBroadcast(user.playingGame);
        }
        private void UpgradeLandTask(OperationRequest operationRequest)
        {
            (user.playingGame.map.blocks[user.player.token.position] as LandBlock).land.Upgrade(user.player);
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                {(byte)UpgradeLandBroadcastParameterItem.PlayerName, user.player.username},
                {(byte)UpgradeLandBroadcastParameterItem.LandName, (user.playingGame.map.blocks[user.player.token.position] as LandBlock).land.name},
                {(byte)UpgradeLandBroadcastParameterItem.NowLevel, (user.playingGame.map.blocks[user.player.token.position] as LandBlock).land.level}
            };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in (user.playingGame as ServerGame).users)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.UpgradeLand, parameter);
            if(user.playingGame != null)
                GameUpdateBroadcast(user.playingGame);
        }
        private void GiveUpTask(OperationRequest operationRequest)
        {

        }
        private void EndTurnTask(OperationRequest operationRequest)
        {
            user.playingGame.EndTurn();
            GameUpdateBroadcast(user.playingGame);
        }
        private void LogOutTask(OperationRequest operationRequest)
        {
            server.UserOffline(user);
            LobbyUpdateBroadcast(server.lobby);
            OperationResponse response = new OperationResponse
                   (
                       operationRequest.OperationCode,
                       (byte)ReturnCode.Correct,
                       "",
                       new Dictionary<byte, object>()
                   );
            server.logger.Info(string.Format("{0} 登出成功", user.userName));
            SendResponse(response);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyProtocol;
using OnlineGameDataStructure;
using Newtonsoft.Json;

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
            
        }
        private void CancleReadyTask(OperationRequest operationRequest)
        {

        }
        private void StartGameTask(OperationRequest operationRequest)
        {

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

        }
        private void BuyLandTask(OperationRequest operationRequest)
        {

        }
        private void UpgradeLandTask(OperationRequest operationRequest)
        {

        }
        private void GetPlayerDataTask(OperationRequest operationRequest)
        {

        }
        private void GiveUpTask(OperationRequest operationRequest)
        {

        }
    }
}
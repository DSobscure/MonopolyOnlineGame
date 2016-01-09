using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyProtocol;
using OnlineGameDataStructure;

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
                if(server.UserOnline(user = new ServerUser(userName, this)))
                {
                    OperationResponse response = new OperationResponse
                        (
                            operationRequest.OperationCode,
                            (byte)ReturnCode.Correct,
                            "",
                            new Dictionary<byte, object>()
                        );
                    server.logger.Info(string.Format("{0} 登入成功", user.UserName));
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

                if (SendMessage(message))
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
        private void SearchRoomTask(OperationRequest operationRequest)
        {

        }
        private void SearchPlayerTask(OperationRequest operationRequest)
        {

        }
        private void CreateRoomTask(OperationRequest operationRequest)
        {

        }
        private void JoinRoomTask(OperationRequest operationRequest)
        {

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
        private void ExitGameTask(OperationRequest operationRequest)
        {

        }
        private void CloseRoomTask(OperationRequest operationRequest)
        {

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

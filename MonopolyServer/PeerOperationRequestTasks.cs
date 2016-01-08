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
    }
}

using MonopolyProtocol;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonopolyServer
{
    abstract class PeerBase
    {
        protected Guid guid;
        TcpClient tcpClient;
        protected Server server;

        protected PeerBase(Guid guid, TcpClient tcpClient, Server server)
        {
            this.guid = guid;
            this.tcpClient = tcpClient;
            this.server = server;
            Task.Run(()=>PeerMain());
        }

        void PeerMain()
        {
            try
            {
                byte[] receiveBuffer = new byte[65535];
                while (!(tcpClient.Client.Poll(0,SelectMode.SelectRead) && tcpClient.Available == 0))
                {
                    if (tcpClient.GetStream().DataAvailable)
                    {
                        int bytes = tcpClient.GetStream().Read(receiveBuffer, 0, tcpClient.Available);
                        OnOperationRequest(JsonConvert.DeserializeObject<OperationRequest>(Encoding.Default.GetString(receiveBuffer, 0, bytes), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                    }
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                server.logger.Error(guid.ToString() + " : " + ex.Message);
                server.logger.Error(guid.ToString() + " : " + ex.StackTrace);
            }
            OnDisconnect();
        }

        protected abstract void OnDisconnect();        

        protected abstract void OnOperationRequest(OperationRequest operationRequest);

        protected void SendResponse(OperationResponse operationResponse)
        {
            try
            { 
                byte[] data = Encoding.Default.GetBytes(JsonConvert.SerializeObject(new CommunicationParameter((byte)ParamaterType.OperationResponse, operationResponse), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                tcpClient.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                server.logger.Error(guid.ToString() + " : " + ex.Message);
                server.logger.Error(guid.ToString() + " : " + ex.StackTrace);
            }
        }
    }
}

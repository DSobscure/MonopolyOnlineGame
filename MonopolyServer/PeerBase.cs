using MonopolyProtocol;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonopolyServer
{
    public abstract class PeerBase
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
                while (!(tcpClient.Client.Poll(0,SelectMode.SelectRead) && tcpClient.Available == 0))
                {
                    if (tcpClient.GetStream().DataAvailable)
                    {
                        byte[] receiveBuffer = new byte[1000000];
                        int bytes = tcpClient.GetStream().Read(receiveBuffer, 0, tcpClient.Available);
                        string result = Encoding.Default.GetString(receiveBuffer, 0, bytes);
                        string[] splitResult = result.Split(new string[] { "XXXXXXXX" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in splitResult)
                        {
                            OnOperationRequest(JsonConvert.DeserializeObject<OperationRequest>(s, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                        }
                    }
                    Thread.Sleep(10);
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

        internal void SendResponse(OperationResponse operationResponse)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(JsonConvert.SerializeObject(new CommunicationParameter((byte)ParamaterType.OperationResponse, operationResponse), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto })+ "XXXXXXXX");
                tcpClient.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                server.logger.Error(guid.ToString() + " : " + ex.Message);
                server.logger.Error(guid.ToString() + " : " + ex.StackTrace);
            }
        }
        internal void SendEvent(EventData eventData)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(JsonConvert.SerializeObject(new CommunicationParameter((byte)ParamaterType.EventData, eventData), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto })+ "XXXXXXXX");
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

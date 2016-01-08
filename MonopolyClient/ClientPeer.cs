using MonopolyProtocol;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;

namespace MonopolyClient
{
    public class ClientPeer
    {
        TcpClient tcpClient;
        IPeerService peerService;
        byte[] receiveBuffer = new byte[65535];

        public ClientPeer(IPeerService peerService)
        {
            this.peerService = peerService;
            tcpClient = new TcpClient();
        }

        public bool Connect(string hostname, int port)
        {
            try
            {
                tcpClient.Connect(hostname, port);
            }
            catch(Exception ex)
            {
                peerService.DebugReturn(DebugLevel.Error, ex.Message);
                peerService.DebugReturn(DebugLevel.Error, ex.StackTrace);
            }
            return tcpClient.Connected;
        }

        public void Disconnect()
        {
            tcpClient.Close();
        }

        public void Send(OperationRequest operationRequest)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(JsonConvert.SerializeObject(operationRequest, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                tcpClient.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                peerService.DebugReturn(DebugLevel.Error, ex.Message);
                peerService.DebugReturn(DebugLevel.Error, ex.StackTrace);
            }
        }

        public void Service()
        {
            try
            {
                if (!(tcpClient.Client.Poll(0, SelectMode.SelectRead) && tcpClient.Available == 0))
                {
                    if (tcpClient.GetStream().DataAvailable)
                    {
                        int bytes = tcpClient.GetStream().Read(receiveBuffer, 0, tcpClient.Available);
                        CommunicationParameter parameter = JsonConvert.DeserializeObject<CommunicationParameter>(Encoding.Default.GetString(receiveBuffer, 0, bytes), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                        switch(parameter.ParameterType)
                        {
                            case (byte)ParamaterType.OperationResponse:
                                peerService.OnOperationResponse(parameter.Parameter as OperationResponse);
                                break;
                            case (byte)ParamaterType.EventData:
                                peerService.OnEvent(parameter.Parameter as EventData);
                                break;
                        }                            
                    }
                }
                else
                    peerService.OnStatusChanged(StatusCode.Disconnect);
                }
            catch (Exception ex)
            {
                peerService.DebugReturn(DebugLevel.Error, ex.Message);
                peerService.DebugReturn(DebugLevel.Error, ex.StackTrace);
            }
        }
    }
}

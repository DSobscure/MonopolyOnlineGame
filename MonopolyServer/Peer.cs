using OnlineGameDataStructure;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace MonopolyServer
{
    class Peer
    {
        Guid guid;
        TcpClient tcpClient;
        Server server;
        User user;

        public Peer(Guid guid, TcpClient tcpClient, Server server)
        {
            this.guid = guid;
            this.tcpClient = tcpClient;
            this.server = server;
            Task.Run(()=>PeerMain());
        }

        void PeerMain()
        {
            byte[] receiveBuffer = new byte[65535];
            while (tcpClient.Connected && tcpClient.GetStream().DataAvailable)
            {
                try
                {
                    int bytes = tcpClient.GetStream().Read(receiveBuffer, 0, tcpClient.Available);
                    OnOperationRequest(JsonConvert.DeserializeObject<OperationRequest>(Encoding.Default.GetString(receiveBuffer).TrimEnd((char)0)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                Thread.Sleep(1);
            }
            OnDisconnect();
        }

        void OnDisconnect()
        {
            Console.WriteLine("Disconnect");
        }

        void OnOperationRequest(OperationRequest operationRequest)
        {
            server.logger.Info(guid.ToString() + " : " + operationRequest.OperationCode);
            //switch(operationRequest.OperationCode)
            //{

            //}
        }
    }
}

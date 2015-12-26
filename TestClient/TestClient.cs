using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using HeptagramServer;

namespace TestClient
{
    class TestClient
    {
        TcpClient tcpClient;
        string server_ip;
        int server_port;

        public TestClient(string ip, int port)
        {
            server_ip = ip;
            server_port = port;
            Console.WriteLine("This is the test client");
            Console.WriteLine("enter 'connect' to connect to server");
            Console.WriteLine();
            while (true)
            {
                string command;
                Console.Write(">");
                command = Console.ReadLine();
                switch (command)
                {
                    case "exit":
                        return;
                    case "connect":
                        ConnectTask();
                        break;
                    default:
                        Console.WriteLine("nothing");
                        break;
                }
            }
        }

        private void Send(OperationRequest operationRequest)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = Encoding.Default.GetBytes(JsonConvert.SerializeObject(operationRequest, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                stream.Write(data, 0, data.Length);
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
        }
        
        private void ConnectTask()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(server_ip, server_port);
                Console.WriteLine("connect to server");
                //Send(new OperationRequest() { OperationCode = 0, Parameters = new Dictionary<byte, object>() });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Can not connect to ip:{0} port:{1} please check or try again!", server_ip, server_port);
            }
        }
        
    }
}

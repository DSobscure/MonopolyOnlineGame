using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace HeptagramServer
{
    public class Peer
    {
        private Guid _guid;
        public Guid guid
        {
            get
            {
                return _guid;
            }
        }

        private Socket _socket;
        public Socket socket
        {
            get
            {
                return _socket;
            }
        }

        public Peer(Guid guid, Socket socket)
        {
            _guid = guid;
            _socket = socket;
            Console.WriteLine("Peer connected");
            Task task = new Task(PeerMain);
            task.Start();
        }

        private void PeerMain()
        {
            byte[] buffer = new byte[65535];
            while (true)
            {
                try
                {
                    int dataLength = socket.Receive(buffer);
                    OperationRequest operationRequest = JsonConvert.DeserializeObject<OperationRequest>(Encoding.Default.GetString(buffer, 0, dataLength), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    OnOperationRequest(operationRequest);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        protected void OnOperationRequest(OperationRequest operationRequest)
        {
            Console.WriteLine(guid.ToString() + " : " + operationRequest.OperationCode);
            //switch(operationRequest.OperationCode)
            //{

            //}
        }
    }
}

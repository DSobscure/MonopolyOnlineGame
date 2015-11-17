using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string server_ip = "140.113.123.134";
            int server_port = 23*98;
            TestClient client = new TestClient(server_ip, server_port);
        }
    }
}

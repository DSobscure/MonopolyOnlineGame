using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeptagramServerExecutiveEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutiveServer server = new ExecutiveServer(23*98);
            while (!server.isTerminated)
            {
                Thread.Sleep(100);
            }
        }
    }
}

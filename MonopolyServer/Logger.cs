using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyServer
{
    class Logger
    {
        bool isDebug = true;
        bool isInfo = true;

        public void Debug(string message)
        {
            if(isDebug)
                Console.Write("{0} DEBUG - {1}", DateTime.Now.ToString("o"), message);
        }
        public void Info(string message)
        {
            if(isInfo)
                Console.Write("{0} Info - {1}", DateTime.Now.ToString("o"), message);
        }
    }
}

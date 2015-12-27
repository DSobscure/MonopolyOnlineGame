using System;

namespace MonopolyServer
{
    class Logger
    {
        bool isDebug = true;
        bool isInfo = true;
        bool isError = true;

        public void Debug(string message)
        {
            if(isDebug)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} DEBUG - {1}", DateTime.Now.ToString("o"), message);
            }
        }
        public void Info(string message)
        {
            if(isInfo)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0} Info - {1}", DateTime.Now.ToString("o"), message);
            }
        }
        public void Error(string message)
        {
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} Error - {1}", DateTime.Now.ToString("o"), message);
            }
        }
    }
}

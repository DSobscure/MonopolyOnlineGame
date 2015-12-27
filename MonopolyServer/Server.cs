using MonopolyGame;
using OnlineGameDataStructure;
using System.Collections.Generic;

namespace MonopolyServer
{
    class Server
    {
        string version = "0.0.1";
        internal Logger logger;
        Dictionary<int, User> userDictionary;
        Dictionary<int, Game> gameDictionary;

        public Server()
        {
            logger = new Logger();
            userDictionary = new Dictionary<int, User>();
            gameDictionary = new Dictionary<int, Game>();
        }
    }
}

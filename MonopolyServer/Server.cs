using MonopolyGame;
using OnlineGameDataStructure;
using System.Collections.Generic;

namespace MonopolyServer
{
    class Server
    {
        string version;
        internal Logger logger;
        Dictionary<int, User> userDictionary;
        Dictionary<int, Game> gameDictionary;
    }
}

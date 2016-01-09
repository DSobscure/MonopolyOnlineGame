using MonopolyGame;
using OnlineGameDataStructure;
using System.Collections.Generic;
using MonopolyProtocol;

namespace MonopolyServer
{
    class Server
    {
        string version = "0.0.1";
        internal Logger logger;
        Dictionary<string, User> userDictionary;
        Dictionary<int, Game> gameDictionary;
        Lobby lobby;

        public Server()
        {
            logger = new Logger();
            userDictionary = new Dictionary<string, User>();
            gameDictionary = new Dictionary<int, Game>();
            lobby = new Lobby();
        }

        public void Broadcast(Peer[] peers, BroadcastType broadcastType, Dictionary<byte, object> parameter)
        {
            EventData eventData = new EventData((byte)broadcastType, parameter);
            foreach (Peer peer in peers)
            {
                peer.SendEvent(eventData);
            }
        }

        public bool UserOnline(User user)
        {
            if(!userDictionary.ContainsKey(user.UserName))
            {
                userDictionary.Add(user.UserName, user);
                lobby.UserEnter(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UserOffline(User user)
        {
            if (userDictionary.ContainsKey(user.UserName))
            {
                userDictionary.Remove(user.UserName);
                lobby.UserExit(user);
            }
        }
    }
}

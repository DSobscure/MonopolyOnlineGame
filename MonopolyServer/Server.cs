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
        Dictionary<string, ServerUser> userDictionary;
        Dictionary<int, Game> gameDictionary;
        internal ServerLobby lobby;

        public Server()
        {
            logger = new Logger();
            userDictionary = new Dictionary<string, ServerUser>();
            gameDictionary = new Dictionary<int, Game>();
            lobby = new ServerLobby();
        }

        public void Broadcast(Peer[] peers, BroadcastType broadcastType, Dictionary<byte, object> parameter)
        {
            EventData eventData = new EventData((byte)broadcastType, parameter);
            foreach (Peer peer in peers)
            {
                peer.SendEvent(eventData);
            }
        }

        public bool UserOnline(ServerUser user)
        {
            if(!userDictionary.ContainsKey(user.userName))
            {
                userDictionary.Add(user.userName, user);
                user.MoveToUserGroup(lobby);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UserOffline(ServerUser user)
        {
            if (userDictionary.ContainsKey(user.userName))
            {
                userDictionary.Remove(user.userName);
                user.MoveToUserGroup(null);
            }
        }
    }
}

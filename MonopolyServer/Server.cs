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

            lobby.CreateRoom(new User("test host1"), "test room1", false, "");
            lobby.CreateRoom(new User("test host2"), "test room2", true, "room2");
            lobby.CreateRoom(new User("test host3"), "test room3", false, "");
            lobby.CreateRoom(new User("test host4"), "test room4", true, "room4");
            lobby.CreateRoom(new User("test host5"), "test room5", false, "");
            lobby.CreateRoom(new User("test host6"), "test room6", true, "room6");
            lobby.CreateRoom(new User("test host7"), "test room7", false, "");
            lobby.CreateRoom(new User("test host8"), "test room8", false, "");
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

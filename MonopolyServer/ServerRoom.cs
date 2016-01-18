using System.Collections.Generic;
using OnlineGameDataStructure;
using System.Linq;

namespace MonopolyServer
{
    class ServerRoom : Room
    {
        public Lobby lobby { get; protected set; }
        private static int roomCount = 0;

        public ServerRoom(Lobby lobby, User host, string roomName, bool isEncrypted, string password) :
            base(host, roomName, isEncrypted, password)
        {
            this.lobby = lobby;
            roomCount++;
            id = roomCount;
        }

        public void Close()
        {
            var userList = users.Values.ToList();
            for (int i = 0 ; i < userList.Count; i++)
            {
                (userList[i] as ServerUser).MoveToUserGroup(lobby);
            }
            lobby.rooms.Remove(id);
        }

        public override Room Serialize()
        {
            var serializeUsers = new Dictionary<string, User>();
            foreach(User user in users.Values)
            {
                serializeUsers.Add(user.userName, user.Serialize());
            }
            return new Room(host.Serialize(), id, name, isEncrypted, password, serializeUsers);
        }

        public override void UserEnter(User user)
        {
            users.Add(user.userName, user);
            user.ready = false;
        }

        public override void UserExit(User user)
        {
            if (users.ContainsKey(user.userName))
            {
                users.Remove(user.userName);
                (lobby as ServerLobby).CloseRoom(id);
            }
            user.ready = false;
        }
    }
}

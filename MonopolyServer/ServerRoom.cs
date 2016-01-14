using System.Collections.Generic;
using OnlineGameDataStructure;

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
            foreach (User user in users.Values)
            {
                (user as ServerUser).MoveToUserGroup(lobby);
            }
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
    }
}

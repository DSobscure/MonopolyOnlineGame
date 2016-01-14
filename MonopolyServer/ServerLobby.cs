using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineGameDataStructure;

namespace MonopolyServer
{
    class ServerLobby : Lobby
    {
        public ServerLobby() : base()
        {

        }

        public bool CreateRoom(User host, string roomName, bool isEncrypted, string password)
        {
            if (rooms.Any(x => x.Value.name == roomName || x.Value.host == host))
                return false;
            else
            {
                Room room = new ServerRoom(this, host, roomName, isEncrypted, password);
                rooms.Add(room.id, room);
                room.UserEnter(host);
                return true;
            }
        }

        public bool CloseRoom(int roomID)
        {
            if (rooms.ContainsKey(roomID))
            {
                (rooms[roomID] as ServerRoom).Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Lobby Serialize()
        {
            var serializeUsers = new Dictionary<string, User>();
            foreach (User user in users.Values)
            {
                serializeUsers.Add(user.userName, user.Serialize());
            }
            var serializeRooms = new Dictionary<int,Room>();
            foreach(Room room in rooms.Values)
            {
                serializeRooms.Add(room.id, room.Serialize());
            }
            return new Lobby(serializeUsers, serializeRooms);
        }
    }
}

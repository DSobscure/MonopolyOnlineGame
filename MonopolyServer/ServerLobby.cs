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

        public bool CreateRoom(User host, string roomName, bool isEncrypted, string password, out Room room)
        {
            room = null;
            if (rooms.Any(x => x.Value.name == roomName || x.Value.host == host))
                return false;
            else
            {
                room = new ServerRoom(this, host, roomName, isEncrypted, password);
                rooms.Add(room.id, room);
                (host as ServerUser).MoveToUserGroup(room);
                host.ready = true;
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

        public override void UserEnter(User user)
        {
            users.Add(user.userName, user);
        }

        public override void UserExit(User user)
        {
            if(users.ContainsKey(user.userName))
                users.Remove(user.userName);
        }
    }
}

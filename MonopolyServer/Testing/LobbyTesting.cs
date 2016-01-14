using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineGameDataStructure;

namespace MonopolyServer.Testing
{
    class LobbyTesting
    {
        public LobbyTesting()
        {
            ServerLobby lobby = new ServerLobby();
            ServerUser host = new ServerUser("host", null);
            Console.WriteLine("---------create room------------");
            lobby.CreateRoom(host, "testRoom", true, "asdqwe");
            PrintLobby(lobby);
            Console.WriteLine("---------create room--------------");
            lobby.CreateRoom(host, "testRoom2", false, "");
            lobby.CreateRoom(host, "testRoom3", false, "");
            PrintLobby(lobby);
            string lobbyDataString = JsonConvert.SerializeObject(lobby.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            Lobby resultLobby = JsonConvert.DeserializeObject<Lobby>(lobbyDataString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            PrintLobby(resultLobby);

            Console.WriteLine("Lobby test end");
            Console.Read();
        }

        private void PrintLobby(Lobby lobby)
        {
            foreach (Room room in lobby.rooms.Values)
            {
                Console.WriteLine("Name: "+room.id + ". " + room.name);
                Console.WriteLine("lock: "+room.isEncrypted);
                Console.WriteLine("password: "+room.password);
                foreach (User user in room.users.Values)
                {
                    Console.WriteLine(user.userName);
                }
            }
        }
    }
}

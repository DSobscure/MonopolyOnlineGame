using MonopolyProtocol;
using Newtonsoft.Json;
using OnlineGameDataStructure;
using System.Collections.Generic;

namespace MonopolyServer
{
    partial class Peer : PeerBase
    {
        private bool SendMessageBroadcast(string message)
        {
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
                                        {
                                            {(byte)SendMessageBroadcastParameterItem.SenderName, user.userName },
                                            {(byte)SendMessageBroadcastParameterItem.Message, message}
                                        };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in user.userGroup.users.Values)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.SendMessage, parameter);
            return true;
        }
        private bool JoinRoom(int roomID, string password, out Room room)
        {
            room = null;
            if(server.lobby.rooms.ContainsKey(roomID))
            {
                room = server.lobby.rooms[roomID];
                if(room.isEncrypted)
                {
                    if(room.password == password)
                    {
                        user.MoveToUserGroup(room);
                        RoomUpdateBroadcast(room);
                        return true;
                    }
                    else
                    {
                        room = null;
                        return false;
                    }
                }
                else
                {
                    user.MoveToUserGroup(room);
                    RoomUpdateBroadcast(room);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        private void RoomUpdateBroadcast(Room room)
        {
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
                                        {
                                            {(byte)GameRoomStatusChangeBroadcastParameterItem.GameRoomDataString, JsonConvert.SerializeObject(room.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                                        };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in user.userGroup.users.Values)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.GameRoomStatusChange, parameter);
        }
        private bool CreateRoom(string roomName, bool isEncrypted, string password, out Room room)
        {
            bool result = server.lobby.CreateRoom(user, roomName, isEncrypted, password, out room);
            LobbyUpdateBroadcast(server.lobby);
            return result;
        }
        private void LobbyUpdateBroadcast(Lobby lobby)
        {
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
                                        {
                                            {(byte)LobbyStatusChangeBroadcastParameterItem.LobbyDataString, JsonConvert.SerializeObject(lobby.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                                        };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in user.userGroup.users.Values)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.LobbyStatusChange, parameter);
        }
        private void ExitRoom()
        {
            if(user.userGroup is Room)
            {
                Room room = user.userGroup as Room;
                if(room.host == user)
                {
                    user.MoveToUserGroup(server.lobby);
                    LobbyUpdateBroadcast(server.lobby);
                    RoomUpdateBroadcast(room);
                }
                else
                {
                    user.MoveToUserGroup(server.lobby);
                    RoomUpdateBroadcast(room);
                }
            }
        }
    }
}

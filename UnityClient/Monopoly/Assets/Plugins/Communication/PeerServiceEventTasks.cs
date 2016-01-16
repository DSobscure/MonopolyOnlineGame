using UnityEngine;
using System.Collections;
using MonopolyProtocol;
using System;
using Newtonsoft.Json;
using OnlineGameDataStructure;

public partial class PeerService
{
    public void SendMessageEventTask(EventData eventData)
    {
        try
        {
            if (eventData.Parameters.Count == 2)
            {
                string senderName = (string)eventData.Parameters[(byte)SendMessageBroadcastParameterItem.SenderName];
                string message = (string)eventData.Parameters[(byte)SendMessageBroadcastParameterItem.Message];
                if (OnReceiveMessage != null)
                    OnReceiveMessage(senderName, message);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "SendMessageEventTask parameter error");
            }
        }
        catch (Exception ex)
        {
            DebugReturn(DebugLevel.Error, ex.Message);
            DebugReturn(DebugLevel.Error, ex.StackTrace);
        }
    }
    public void LobbyStatusChangeEventTask(EventData eventData)
    {
        try
        {
            if (eventData.Parameters.Count == 1)
            {
                GameGlobal.lobby = JsonConvert.DeserializeObject<Lobby>((string)eventData.Parameters[(byte)LobbyStatusChangeBroadcastParameterItem.LobbyDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                if (OnLobbyUpdate != null)
                    OnLobbyUpdate(GameGlobal.lobby);
                else
                    DebugReturn(DebugLevel.Error, "event OnLobbyUpdate is null");
            }
            else
            {
                DebugReturn(DebugLevel.Error, "LobbyStatusChangeEventTask parameter error");
            }
        }
        catch (Exception ex)
        {
            DebugReturn(DebugLevel.Error, ex.Message);
            DebugReturn(DebugLevel.Error, ex.StackTrace);
        }
    }
    public void GameRoomStatusChangeEventTask(EventData eventData)
    {
        try
        {
            if (eventData.Parameters.Count == 1)
            {
                Room room = JsonConvert.DeserializeObject<Room>((string)eventData.Parameters[(byte)GameRoomStatusChangeBroadcastParameterItem.GameRoomDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                if(GameGlobal.lobby.rooms.ContainsKey(room.id))
                {
                    GameGlobal.lobby.rooms[room.id] = room;
                    if (OnLobbyUpdate != null)
                        OnLobbyUpdate(GameGlobal.lobby);
                    else
                        DebugReturn(DebugLevel.Error, "event OnLobbyUpdate is null");
                }
                if (GameGlobal.room.id == room.id)
                {
                    GameGlobal.room = room;
                    if (OnRoomUpdate != null)
                        OnRoomUpdate(GameGlobal.room);
                    else
                        DebugReturn(DebugLevel.Error, "event OnLobbyUpdate is null");
                }
            }
            else
            {
                DebugReturn(DebugLevel.Error, "GameRoomStatusChangeEventTask parameter error");
            }
        }
        catch (Exception ex)
        {
            DebugReturn(DebugLevel.Error, ex.Message);
            DebugReturn(DebugLevel.Error, ex.StackTrace);
        }
    }
}

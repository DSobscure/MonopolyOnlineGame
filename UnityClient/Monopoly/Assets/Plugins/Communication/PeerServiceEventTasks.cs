using UnityEngine;
using System.Collections;
using MonopolyProtocol;
using System;
using Newtonsoft.Json;
using OnlineGameDataStructure;
using MonopolyGame;

public partial class PeerService
{
    private void SendMessageEventTask(EventData eventData)
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
    private void LobbyStatusChangeEventTask(EventData eventData)
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
    private void GameRoomStatusChangeEventTask(EventData eventData)
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
    private void GameStartEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 1)
        {
            GameGlobal.playingGame = JsonConvert.DeserializeObject<Game>((string)eventData.Parameters[(byte)GameStartBroadcastParameterItem.GameDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if(OnGameStart != null)
            {
                OnGameStart();
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnGameStart is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "GameStartEventTask parameter error");
        }
    }
    private void MonopolyGameStatusChangeEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 1)
        {
            GameGlobal.playingGame = JsonConvert.DeserializeObject<Game>((string)eventData.Parameters[(byte)GameStartBroadcastParameterItem.GameDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnMonopolyGameUpdate != null)
            {
                OnMonopolyGameUpdate(GameGlobal.playingGame);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnMonopolyGameUpdate is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "MonopolyGameStatusChangeEventTask parameter error");
        }
    }
    private void RollDiceResultEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 1)
        {
            int diceResult = (Int32)(Int64)eventData.Parameters[(byte)RollDiceResultParameterItem.DiceNumber];
            if (OnRollDice != null)
            {
                OnRollDice(diceResult);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnRollDice is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "RollDiceResultEventTask parameter error");
        }
    }
    private void BuyLandSelectionEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 1)
        {
            Land land = JsonConvert.DeserializeObject<Land>((string)eventData.Parameters[(byte)BuyLandSelectionBroadcastParameterItem.LandDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnBuyLandSelection != null)
            {
                OnBuyLandSelection(land);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnBuyLandSelection is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "BuyLandSelectionEventTask parameter error");
        }
    }
    private void UpgradeLandSelectionEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 1)
        {
            Land land = JsonConvert.DeserializeObject<Land>((string)eventData.Parameters[(byte)UpgradeLandSelectionBroadcastParameterItem.LandDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnUpgradeLandSelection != null)
            {
                OnUpgradeLandSelection(land);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnUpgradeLandSelection is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "UpgradeLandSelectionEventTask parameter error");
        }
    }
    private void PayForTollEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 4)
        {
            string playerName = (string)eventData.Parameters[(byte)PayForTollBroadcastParameterItem.PlayerName];
            string landName = (string)eventData.Parameters[(byte)PayForTollBroadcastParameterItem.LandName];
            int toll = (int)(Int64)eventData.Parameters[(byte)PayForTollBroadcastParameterItem.Toll];
            string ownerName = (string)eventData.Parameters[(byte)PayForTollBroadcastParameterItem.LandOwnerName];

            if (OnPayForToll != null)
            {
                OnPayForToll(playerName, landName, toll, ownerName);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnPayForToll is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "PayForTollEventTask parameter error");
        }
    }
    private void PassStartBlockEventTask(EventData eventData)
    {
        if (OnPassStartBlock != null)
        {
            OnPassStartBlock();
        }
        else
        {
            DebugReturn(DebugLevel.Error, "event OnPassStartBlock is null");
        }
    }
    private void DrawCardEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 3)
        {
            string playerName = (string)eventData.Parameters[(byte)DrawCardBroadcastParameterItem.PlayerName];
            string blockType = (string)eventData.Parameters[(byte)DrawCardBroadcastParameterItem.BlockType];
            Card card = JsonConvert.DeserializeObject<Card>((string)eventData.Parameters[(byte)DrawCardBroadcastParameterItem.CardDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnDrawCard != null)
            {
                OnDrawCard(playerName, blockType, card);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnDrawCard is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "DrawCardEventTask parameter error");
        }
    }
    private void BuyLandEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 2)
        {
            string playerName = (string)eventData.Parameters[(byte)BuyLandBroadcastParameterItem.PlayerName];
            string landName = (string)eventData.Parameters[(byte)BuyLandBroadcastParameterItem.LandName];
            if (OnBuyLand != null)
            {
                OnBuyLand(playerName, landName);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnBuyLand is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "BuyLandEventTask parameter error");
        }
    }
    private void UpgradeLandEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 3)
        {
            string playerName = (string)eventData.Parameters[(byte)UpgradeLandBroadcastParameterItem.PlayerName];
            string landName = (string)eventData.Parameters[(byte)UpgradeLandBroadcastParameterItem.LandName];
            int nowLevel = (int)(Int64)eventData.Parameters[(byte)UpgradeLandBroadcastParameterItem.NowLevel];
            if (OnUpgrade != null)
            {
                OnUpgrade(playerName, landName, nowLevel);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnUpgrade is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "UpgradeLandEventTask parameter error");
        }
    }
    private void EndGameEventTask(EventData eventData)
    {
        if (eventData.Parameters.Count == 3)
        {
            string winnerName = (string)eventData.Parameters[(byte)EndGameBroadcastParameterItem.WinerName];
            int winnerMoney = (int)(Int64)eventData.Parameters[(byte)EndGameBroadcastParameterItem.WinerMoney];
            GameGlobal.playingGame = JsonConvert.DeserializeObject<Game>((string)eventData.Parameters[(byte)EndGameBroadcastParameterItem.GameDataString], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnMonopolyGameUpdate != null)
            {
                OnMonopolyGameUpdate(GameGlobal.playingGame);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnMonopolyGameUpdate is null");
            }
            if (OnEndGame != null)
            {
                OnEndGame(winnerName, winnerMoney);
            }
            else
            {
                DebugReturn(DebugLevel.Error, "event OnEndGame is null");
            }
        }
        else
        {
            DebugReturn(DebugLevel.Error, "EndGameEventTask parameter error");
        }
    }
}

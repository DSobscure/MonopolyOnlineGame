using System;
using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;
using MonopolyGame;

public partial class PeerService
{
    public delegate void DebugReturnEventHandler(string debugMessage);
    public event DebugReturnEventHandler OnDebugReturn;

    public delegate void AlertEventHandler(string alertMessage);
    public event AlertEventHandler OnAlert;

    public delegate void ConnectResponseEventHandler(bool status);
    public event ConnectResponseEventHandler OnConnectResponse;

    public delegate void LoginResponseEventHandler(bool status);
    public event LoginResponseEventHandler OnLoginResponse;

    public delegate void GetLobbyDataResponseEventHandler(Lobby lobby);
    public event GetLobbyDataResponseEventHandler OnGetLobbyData;

    public delegate void SendMessageResponseEventHandler(bool status, string errorMessage);
    public event SendMessageResponseEventHandler OnSendMessageResponse;

    public delegate void ReceiveMessageEventHandler(string senderName,string message);
    public event ReceiveMessageEventHandler OnReceiveMessage;

    public delegate void JoinRoomEventHandler(bool status);
    public event JoinRoomEventHandler OnJoinRoom;

    public delegate void LobbyUpdateEventHandler(Lobby lobby);
    public event LobbyUpdateEventHandler OnLobbyUpdate;

    public delegate void RoomUpdateEventHandler(Room room);
    public event RoomUpdateEventHandler OnRoomUpdate;

    public event Action OnGameStart;

    public delegate void MonopolyGameUpdateEventHandler(Game game);
    public event MonopolyGameUpdateEventHandler OnMonopolyGameUpdate;

    public delegate void RollDiceResultEventHandler(int number);
    public event RollDiceResultEventHandler OnRollDice;

    public delegate void BuyLandSelectionEventHandler(Land land);
    public event BuyLandSelectionEventHandler OnBuyLandSelection;

    public delegate void UpgradeLandSelectionEventHandler(Land land);
    public event UpgradeLandSelectionEventHandler OnUpgradeLandSelection;

    public delegate void PayForTollEventHandler(string player, string landName, int toll, string ownerName);
    public event PayForTollEventHandler OnPayForToll;

    public delegate void PassStartBlockEventHandler();
    public event PassStartBlockEventHandler OnPassStartBlock;

    public delegate void DrawCardEventHandler(string playerName, string blockType, Card card);
    public event DrawCardEventHandler OnDrawCard;

    public delegate void BuyLandEventHandler(string playerName, string landName);
    public event BuyLandEventHandler OnBuyLand;

    public delegate void UpgradeLandEventHandler(string playerName, string landName, int nowLevel);
    public event UpgradeLandEventHandler OnUpgrade;

    public delegate void EndGameEventHandler(string playerName, int winerMoney);
    public event EndGameEventHandler OnEndGame;

    public event Action OnLogOut;
}

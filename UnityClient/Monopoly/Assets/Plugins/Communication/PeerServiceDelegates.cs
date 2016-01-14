using System;
using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;

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
}

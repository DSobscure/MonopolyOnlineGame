using System;
using UnityEngine;
using System.Collections;

public partial class PeerService
{
    public delegate void DebugReturnEventHandler(string debugMessage);
    public event DebugReturnEventHandler OnDebugReturn;

    public delegate void ConnectResponseEventHandler(bool status);
    public event ConnectResponseEventHandler OnConnectResponse;

    public event Action OnLoginResponse;
}

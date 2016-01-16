using System;
using MonopolyClient;
using MonopolyProtocol;

public partial class PeerService : IPeerService
{
    public ClientPeer peer { get; protected set; }
    public bool ServerConnected { get; protected set; }

    public PeerService()
    {
        peer = null;
        ServerConnected = false;
    }

    public void Connect(string hostname, int port)
    {
        try
        {
            peer = new ClientPeer(this);
            if (!peer.Connect(hostname, port))
            {
                OnConnectResponse(false);
            }
        }
        catch (Exception ex)
        {
            OnConnectResponse(false);
            DebugReturn(DebugLevel.Error, ex.Message);
            DebugReturn(DebugLevel.Error, ex.StackTrace);
        }
    }

    public void Disconnect()
    {
        peer.Disconnect();
    }

    public void Service()
    {
        peer.Service();
    }

    public void OnEvent(EventData eventData)
    {
        DebugReturn(DebugLevel.Info, "event : " + ((BroadcastType)eventData.EventCode).ToString());
        switch(eventData.EventCode)
        {
            case (byte)BroadcastType.SendMessage:
                SendMessageEventTask(eventData);
                break;
            case (byte)BroadcastType.LobbyStatusChange:
                LobbyStatusChangeEventTask(eventData);
                break;
            case (byte)BroadcastType.GameRoomStatusChange:
                GameRoomStatusChangeEventTask(eventData);
                break;
        }
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        DebugReturn(DebugLevel.Info, "operationResponse : " + ((OperationType)operationResponse.OperationCode).ToString());
        switch(operationResponse.OperationCode)
        {
            case (byte)OperationType.Login:
                LoginResponseTask(operationResponse);
                break;
            case (byte)OperationType.GetLobbyData:
                GetLobbyDataResponseTask(operationResponse);
                break;
            case (byte)OperationType.JoinRoom:
                JoinRoomResponseTask(operationResponse);
                break;
            case (byte)OperationType.CreateRoom:
                CreateRoomResponseTask(operationResponse);
                break;
        }
    }

    public void DebugReturn(DebugLevel debugLevel, string message)
    {
        if(OnDebugReturn != null)
            OnDebugReturn.Invoke(message);
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        throw new NotImplementedException();
    }
}

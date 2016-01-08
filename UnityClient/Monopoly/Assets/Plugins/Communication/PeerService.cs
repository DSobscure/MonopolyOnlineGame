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

    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        DebugReturn(DebugLevel.Info, "OK : "+operationResponse.ReturnCode.ToString());
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

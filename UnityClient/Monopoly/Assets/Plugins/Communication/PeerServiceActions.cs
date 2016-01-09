using UnityEngine;
using System.Collections.Generic;
using MonopolyProtocol;

public partial class PeerService
{
    public void Login(string userName)
    {
        var parameters = new Dictionary<byte, object> {
                             { (byte)LoginParameterItem.UserName, userName }
                        };
        peer.Send(new OperationRequest((byte)OperationType.Login, parameters));
    }
    public void SendMessage(string message)
    {
        var parameters = new Dictionary<byte, object> {
                             { (byte)SendMessageParameterItem.Message, message }
                        };
        peer.Send(new OperationRequest((byte)OperationType.SendMessage, parameters));
    }
    public void CreateRoom()
    {

    }
    public void JoinRoom()
    {

    }
    public void ReadyForGame()
    {

    }
    public void CancleReady()
    {

    }
    public void StartGame()
    {

    }
    public void ExitGame()
    {

    }
    public void CloseRoom()
    {

    }
    public void GetGameData()
    {

    }
    public void RollDice()
    {

    }
    public void BuyLand()
    {

    }
    public void UpgradeLand()
    {

    }
    public void GetPlayerData()
    {

    }
    public void GiveUp()
    {

    }
}

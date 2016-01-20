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
    public void GetLobbyData()
    {
        peer.Send(new OperationRequest((byte)OperationType.GetLobbyData, new Dictionary<byte, object>()));
    }
    public void SendMessage(string message)
    {
        var parameters = new Dictionary<byte, object> {
                             { (byte)SendMessageParameterItem.Message, message }
                        };
        peer.Send(new OperationRequest((byte)OperationType.SendMessage, parameters));
    }
    public void CreateRoom(string roomName, bool isEncrypted, string password = "")
    {
        var parameters = new Dictionary<byte, object> {
            { (byte)CreateRoomParameterItem.RoomName, roomName },
            { (byte)CreateRoomParameterItem.IsEncrypted, isEncrypted },
            { (byte)CreateRoomParameterItem.Password, password }
        };
        peer.Send(new OperationRequest((byte)OperationType.CreateRoom, parameters));
    }
    public void JoinRoom(int roomID, string password = "")
    {
        var parameters = new Dictionary<byte, object> {
            { (byte)JoinRoomParameterItem.RoomID, roomID },
            { (byte)JoinRoomParameterItem.Password, password }
        };
        peer.Send(new OperationRequest((byte)OperationType.JoinRoom, parameters));
    }
    public void ReadyForGame()
    {
        peer.Send(new OperationRequest((byte)OperationType.ReadyForGame, new Dictionary<byte, object>()));
    }
    public void CancleReady()
    {
        peer.Send(new OperationRequest((byte)OperationType.CancleReady, new Dictionary<byte, object>()));
    }
    public void StartGame()
    {
        peer.Send(new OperationRequest((byte)OperationType.StartGame, new Dictionary<byte, object>()));
    }
    public void ExitGame()
    {
        peer.Send(new OperationRequest((byte)OperationType.ExitRoom, new Dictionary<byte, object>()));
    }
    public void GetGameData()
    {
        peer.Send(new OperationRequest((byte)OperationType.GetGameData, new Dictionary<byte, object>()));
    }
    public void RollDice()
    {
        peer.Send(new OperationRequest((byte)OperationType.RollDice, new Dictionary<byte, object>()));
    }
    public void BuyLand()
    {
        peer.Send(new OperationRequest((byte)OperationType.BuyLand, new Dictionary<byte, object>()));
    }
    public void UpgradeLand()
    {
        peer.Send(new OperationRequest((byte)OperationType.UpgradeLand, new Dictionary<byte, object>()));
    }
    public void GetPlayerData()
    {
        peer.Send(new OperationRequest((byte)OperationType.GetPlayerData, new Dictionary<byte, object>()));
    }
    public void GiveUp()
    {
        peer.Send(new OperationRequest((byte)OperationType.GiveUp, new Dictionary<byte, object>()));
    }
    public void EndTurn()
    {
        peer.Send(new OperationRequest((byte)OperationType.EndTurn, new Dictionary<byte, object>()));
    }
    public void LogOut()
    {
        peer.Send(new OperationRequest((byte)OperationType.LogOut, new Dictionary<byte, object>()));
    }
}

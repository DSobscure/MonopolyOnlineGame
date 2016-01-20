using MonopolyProtocol;
using OnlineGameDataStructure;
using Newtonsoft.Json;
using System;

public partial class PeerService
{
    private void LoginResponseTask(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (byte)ReturnCode.Correct)
        {
            GameGlobal.LoginStatus = true;
            GameGlobal.userName = (string)operationResponse.Parameters[(byte)LoginResponseItem.UserName];
            if (OnLoginResponse != null)
                OnLoginResponse(true);
        }
        else
        {
            GameGlobal.LoginStatus = false;
            if (OnAlert != null)
                OnAlert(operationResponse.DebugMessage);
            if (OnLoginResponse != null)
                OnLoginResponse(false);
        }
    }
    private void GetLobbyDataResponseTask(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (byte)ReturnCode.Correct)
        {
            string lobbyDataString = (string)operationResponse.Parameters[(byte)GetLobbyDataResponseItem.LobbyDataString];
            GameGlobal.lobby = JsonConvert.DeserializeObject<Lobby>(lobbyDataString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnGetLobbyData != null)
                OnGetLobbyData(GameGlobal.lobby);
        }
    }
    private void SendMessageResponseTask(OperationResponse operationResponse)
    {

    }
    private void CreateRoomResponseTask(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (byte)ReturnCode.Correct)
        {
            string roomDataString = (string)operationResponse.Parameters[(byte)CreateRoomResponseItem.RoomDataString];
            GameGlobal.room = JsonConvert.DeserializeObject<Room>(roomDataString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnJoinRoom != null)
                OnJoinRoom(true);
        }
        else
        {
            if (OnAlert != null)
                OnAlert(operationResponse.DebugMessage);
        }
    }
    private void JoinRoomResponseTask(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (byte)ReturnCode.Correct)
        {
            string roomDataString = (string)operationResponse.Parameters[(byte)JoinRoomResponseItem.RoomDataString];
            GameGlobal.room = JsonConvert.DeserializeObject<Room>(roomDataString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            if (OnJoinRoom != null)
                OnJoinRoom(true);
        }
        else
        {
            if(OnAlert != null)
                OnAlert(operationResponse.DebugMessage);
        }
    }
    private void ExitGameResponseTask(OperationResponse operationResponse)
    {

    }
    private void RollDiceResponseTask(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (byte)ReturnCode.Correct)
        {
        }
        else
        {
            if (OnAlert != null)
                OnAlert(operationResponse.DebugMessage);
        }
    }
    private void GiveUpResponseTask(OperationResponse operationResponse)
    {

    }
    private void LogOutResponseTask(OperationResponse operationResponse)
    {
        GameGlobal.LoginStatus = false;
        GameGlobal.userName = "";
        GameGlobal.lobby = null;
        GameGlobal.room = null;
        GameGlobal.playingGame = null;
        if (OnLogOut != null)
            OnLogOut();
    }
}

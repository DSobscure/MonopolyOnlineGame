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

    }
    private void JoinRoomResponseTask(OperationResponse operationResponse)
    {

    }
    private void ReadyForGameResponseTask(OperationResponse operationResponse)
    {

    }
    private void CancleReadyResponseTask(OperationResponse operationResponse)
    {

    }
    private void StartGameResponseTask(OperationResponse operationResponse)
    {

    }
    private void ExitGameResponseTask(OperationResponse operationResponse)
    {

    }
    private void CloseRoomResponseTask(OperationResponse operationResponse)
    {

    }
    private void GetGameDataResponseTask(OperationResponse operationResponse)
    {

    }
    private void RollDiceResponseTask(OperationResponse operationResponse)
    {

    }
    private void BuyLandResponseTask(OperationResponse operationResponse)
    {

    }
    private void UpgradeLandResponseTask(OperationResponse operationResponse)
    {

    }
    private void GetPlayerDataResponseTask(OperationResponse operationResponse)
    {

    }
    private void GiveUpResponseTask(OperationResponse operationResponse)
    {

    }
}

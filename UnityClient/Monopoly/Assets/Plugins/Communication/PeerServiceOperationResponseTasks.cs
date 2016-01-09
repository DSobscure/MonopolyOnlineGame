using MonopolyProtocol;
using System;

public partial class PeerService
{
    private void LoginResponseTask(OperationResponse operationResponse)
    {
        try
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
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SendMessageResponseTas(OperationResponse operationResponse)
    {

    }
    private void CreateRoomResponseTas(OperationResponse operationResponse)
    {

    }
    private void JoinRoomResponseTas(OperationResponse operationResponse)
    {

    }
    private void ReadyForGameResponseTas(OperationResponse operationResponse)
    {

    }
    private void CancleReadyResponseTas(OperationResponse operationResponse)
    {

    }
    private void StartGameResponseTas(OperationResponse operationResponse)
    {

    }
    private void ExitGameResponseTas(OperationResponse operationResponse)
    {

    }
    private void CloseRoomResponseTas(OperationResponse operationResponse)
    {

    }
    private void GetGameDataResponseTas(OperationResponse operationResponse)
    {

    }
    private void RollDiceResponseTas(OperationResponse operationResponse)
    {

    }
    private void BuyLandResponseTas(OperationResponse operationResponse)
    {

    }
    private void UpgradeLandResponseTas(OperationResponse operationResponse)
    {

    }
    private void GetPlayerDataResponseTas(OperationResponse operationResponse)
    {

    }
    private void GiveUpResponseTas(OperationResponse operationResponse)
    {

    }
}

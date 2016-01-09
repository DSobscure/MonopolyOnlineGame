namespace MonopolyProtocol
{
    public enum OperationType : byte
    {
        Login,
        GetLobbyData,
        SendMessage,
        CreateRoom,
        JoinRoom,
        ReadyForGame,
        CancleReady,
        StartGame,
        ExitGame,
        CloseRoom,
        GetGameData,
        RollDice,
        BuyLand,
        UpgradeLand,
        GetPlayerData,
        GiveUp
    }
}

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
        ExitRoom,
        GetGameData,
        RollDice,
        BuyLand,
        UpgradeLand,
        GetPlayerData,
        GiveUp
    }
}

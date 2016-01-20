namespace MonopolyProtocol
{
    public enum BroadcastType : byte
    {
        Alert,
        Online,
        LobbyStatusChange,
        GameRoomStatusChange,
        GameInvite,
        SendMessage,
        GameStart,
        MonopolyGameStatusChange,
        CloseGame,
        RollDiceResult,
        BuyLandSelection,
        UpgradeLandSelection,
        PayForToll,
        PassStartBlock,
        DrawCard,
        BuyLand,
        UpgradeLand,
        EndGame
    }
}

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
        MonopolyGameEvents
    }
}

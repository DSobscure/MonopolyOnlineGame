namespace MonopolyProtocol
{
    public enum AlertBroadcastParameterItem : byte
    {
        AlertMessage
    }
    public enum OnlineBroadcastParameterItem : byte
    {
        UserDataString
    }
    public enum LobbyStatusChangeBroadcastParameterItem : byte
    {
        LobbyDataString
    }
    public enum GameRoomStatusChangeBroadcastParameterItem : byte
    {
        GameRoomDataString
    }
    public enum GameInviteBroadcastParameterItem : byte
    {
        InviterName,
        RoomID
    }
    public enum SendMessageBroadcastParameterItem : byte
    {
        SenderName,
        Message
    }
    public enum MonopolyGameEventsBroadcastParameterItem : byte
    {

    }
}

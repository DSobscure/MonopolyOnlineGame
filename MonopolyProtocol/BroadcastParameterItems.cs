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
    public enum GameStartBroadcastParameterItem : byte
    {
        GameDataString
    }
    public enum MonopolyGameStatusChangeBroadcastParameterItem : byte
    {
        GameDataString
    }
    public enum CloseGameBroadcastParameterItem : byte
    {
        Winner,
        GameDataString
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

    public enum RollDiceResultParameterItem : byte
    {
        DiceNumber
    }

    public enum BuyLandSelectionBroadcastParameterItem : byte
    {
        LandDataString
    }
    public enum UpgradeLandSelectionBroadcastParameterItem : byte
    {
        LandDataString
    }
    public enum PayForTollBroadcastParameterItem : byte
    {
        PlayerName,
        LandName,
        Toll,
        LandOwnerName,
    }
    public enum DrawCardBroadcastParameterItem : byte
    {
        PlayerName,
        BlockType,
        CardDataString
    }
    public enum BuyLandBroadcastParameterItem : byte
    {
        PlayerName,
        LandName
    }
    public enum UpgradeLandBroadcastParameterItem : byte
    {
        PlayerName,
        LandName,
        NowLevel
    }
    public enum EndGameBroadcastParameterItem : byte
    {
        WinerName,
        WinerMoney,
        GameDataString
    }
}

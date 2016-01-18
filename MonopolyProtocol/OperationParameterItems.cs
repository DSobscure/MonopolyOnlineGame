namespace MonopolyProtocol
{
    public enum LoginParameterItem : byte
    {
        UserName
    }
    public enum SendMessageParameterItem : byte
    {
        Message
    }
    public enum CreateRoomParameterItem : byte
    {
        RoomName,
        IsEncrypted,
        Password
    }
    public enum JoinRoomParameterItem : byte
    {
        RoomID,
        Password
    }
    public enum UpgradeLandParameterItem : byte
    {

    }
    public enum GetPlayerDataParameterItem : byte
    {

    }   
}

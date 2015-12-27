namespace MonopolyProtocol
{
    public enum StatusCode
    {
        Connect,
        Disconnect
    }

    public enum DebugLevel
    {
        Degug,
        Info,
        Error
    }

    public interface IPeerService
    {
        void OnEvent(EventData eventData);
        void OnOperationResponse(OperationResponse operationResponse);
        void OnStatusChanged(StatusCode statusCode);
        void DebugReturn(DebugLevel debugLevel, string message);
    }
}

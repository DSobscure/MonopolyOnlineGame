using Newtonsoft.Json;

namespace MonopolyProtocol
{
    public class OperationResponse : CommunicationParameter
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }
        [JsonProperty("ReturnCode")]
        public byte ReturnCode { get; set; }
    }
}

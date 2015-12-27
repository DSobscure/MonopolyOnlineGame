using Newtonsoft.Json;

namespace MonopolyProtocol
{
    public class EventData : CommunicationParameter
    {
        [JsonProperty("Code")]
        public byte Code { get; set; }
    }
}

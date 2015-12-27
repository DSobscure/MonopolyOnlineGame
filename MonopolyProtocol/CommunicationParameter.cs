using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyProtocol
{
    public abstract class CommunicationParameter
    {
        [JsonProperty("Parameters")]
        public Dictionary<byte, object> Parameters { get; set; }
    }
}

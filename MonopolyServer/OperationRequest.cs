using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyServer
{
    class OperationRequest
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }
        [JsonProperty("Parameters")]
        public Dictionary<byte, object> Parameters { get; set; }
    }
}

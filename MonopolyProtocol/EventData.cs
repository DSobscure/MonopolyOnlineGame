using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyProtocol
{
    public class EventData : GeneralParameter
    {
        [JsonProperty("Code")]
        public byte EventCode { get; set; }

        public EventData(byte eventCode, Dictionary<byte, object> parameters) : base(parameters)
        {
            EventCode = eventCode;
        }
    }
}

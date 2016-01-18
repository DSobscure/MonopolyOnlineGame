using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyProtocol
{
    public class OperationResponse : GeneralParameter
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }
        [JsonProperty("ReturnCode")]
        public byte ReturnCode { get; set; }
        [JsonProperty("DebugMessage")]
        public string DebugMessage { get; set; }

        public OperationResponse(byte operationCode, byte returnCode, string debugMessage,Dictionary<byte, object> parameters) : base(parameters)
        {
            OperationCode = operationCode;
            ReturnCode = returnCode;
            DebugMessage = debugMessage;
        }
    }
}

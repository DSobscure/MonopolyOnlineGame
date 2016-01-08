using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyProtocol
{
    public class OperationRequest : GeneralParameter
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }

        public OperationRequest(byte operationCode, Dictionary<byte, object> parameters) : base(parameters)
        {
            OperationCode = operationCode;
        }
    }
}

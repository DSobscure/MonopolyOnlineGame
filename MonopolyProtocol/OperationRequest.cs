﻿using Newtonsoft.Json;

namespace MonopolyProtocol
{
    public class OperationRequest : CommunicationParameter
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }
    }
}

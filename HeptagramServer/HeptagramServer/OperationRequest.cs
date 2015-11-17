using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeptagramServer
{
    public class OperationRequest
    {
        [JsonProperty("OperationCode")]
        public byte OperationCode { get; set; }
        [JsonProperty("Parameters")]
        public Dictionary<byte, object> Parameters { get; set; }
    }
}

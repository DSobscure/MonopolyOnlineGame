using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyProtocol
{
    public enum ParamaterType : byte
    {
        OperationRequest,
        OperationResponse,
        EventData
    }

    public abstract class GeneralParameter
    {
        [JsonProperty("Parameters")]
        public Dictionary<byte, object> Parameters { get; set; }

        public GeneralParameter(Dictionary<byte, object> parameters)
        {
            Parameters = parameters;
        }
    }

    public class CommunicationParameter
    {
        [JsonProperty("ParameterType")]
        public byte ParameterType { get; set; }
        [JsonProperty("Parameter")]
        public GeneralParameter Parameter { get; set; }

        public CommunicationParameter(byte parameterType, GeneralParameter parameter)
        {
            ParameterType = parameterType;
            Parameter = parameter;
        }
    }
}

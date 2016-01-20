using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class LandBlock : Block
    {
        [JsonProperty("land")]
        public Land land { get; set; }

        [JsonConstructor]
        public LandBlock(Land land, List<Token> tokens) : base(tokens)
        {
            this.land = land;
        }

        public LandBlock(Land land) : base()
        {
            this.land = land;
        }
    }
}
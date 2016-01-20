using System;
using Newtonsoft.Json;

namespace MonopolyGame
{
    //=============================================================
    // Token class
    //   Use for controling a player's position.
    //=============================================================
    public class Token
    {
        // Attributes //
        [JsonProperty("ownerName")]
        public string ownerName { get; private set; }
        [JsonProperty("position")]
        public int position { get; set; }

        // Functions //
        [JsonConstructor]
        public Token(int position, string ownerName)
        {
            this.position = position;
            this.ownerName = ownerName;
        }

        public Token(string ownerName)
        {
            this.ownerName = ownerName;
        }
    }
}
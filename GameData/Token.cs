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
        public Player owner { get; }
        public int position { get; set; }

        // Functions //
        public Token(Player owner)
        {
            this.owner = owner;
        }
    }
}
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    //=============================================================
    // Token class
    //   Use for controling a player's position.
    //=============================================================
    public class Token
    {
        // Attributes //
        public int playerId { get; }
        public int mapId { get; set; }
        public int blockPosition { get; set; }
        public int stepsLeft { get; set; }

        // Functions //
        protected Token( int id )
        {
            this.playerId = id;
            this.mapId = -1;
            this.blockPosition = 0;
            this.stepsLeft = 0;
        }

        public void Move()
        {
            while (this.stepsLeft-- > 0)
            {
                this.blockPosition = Monopoly::Map.NextBlock(this.blockPosition);
                
            }
        }
    }
}
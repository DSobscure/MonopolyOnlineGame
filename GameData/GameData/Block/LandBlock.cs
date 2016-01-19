using System;

namespace MonopolyGame
{
    public class LandBlock : Block
    {
        public Land land { get; set; }

        public LandBlock(Map map, Land land) : base(map)
        {
            this.land = land;
        }
    }
}
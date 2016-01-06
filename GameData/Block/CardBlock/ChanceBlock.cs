using System;

namespace MonopolyGame
{
    public class ChanceBlock : CardBlock
    {
        public ChanceBlock(Map map) : base(map, map.game.chanceDeck)
        {

        }
    }
}
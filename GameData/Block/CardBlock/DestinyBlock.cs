using System;

namespace MonopolyGame
{
    public class DestinyBlock : CardBlock
    {
        public DestinyBlock(Map map) : base(map, map.game.destinyDeck)
        {

        }
    }
}
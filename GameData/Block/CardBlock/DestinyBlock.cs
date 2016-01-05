using System;

namespace MonopolyGame
{
    public class DestinyBlock : CardBlock
    {
        public DestinyBlock()
        {
            deck = this.map.game.destinyDeck;
        }
    }
}
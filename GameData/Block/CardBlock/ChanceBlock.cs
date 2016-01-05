using System;

namespace MonopolyGame
{
    public class ChanceBlock : CardBlock
    {
        public ChanceBlock()
        {
            deck = this.map.game.chanceDeck;
        }
    }
}
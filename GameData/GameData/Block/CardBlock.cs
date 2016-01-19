using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class CardBlock : Block
    {
        protected Deck deck { get; set; }

        public CardBlock(Map map, Deck deck) : base(map)
        {
            this.deck = deck;
        }

        public Card Draw()
        {
            return deck.Draw();
        }
    }
}
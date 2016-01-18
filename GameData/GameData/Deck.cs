using System.Collections.Generic;
using System.Linq;
using System;

namespace MonopolyGame
{
    public abstract class Deck
    {
        protected List<Card> cards;
        public int deckSize { get { return cards.Count; } }

        public Card Draw()
        {
            Card drawResult = cards[new Random().Next(deckSize)];
            return drawResult;
        }
    }
}
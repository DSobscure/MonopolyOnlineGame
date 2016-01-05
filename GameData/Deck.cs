using System.Collections.Generic;
using System.Linq;
using System;

namespace MonopolyGame
{
    public abstract class Deck
    {
        protected List<Card> cards { get; }

        public Event Draw()
        {
            return this.events[new Random().Next(this.DeckSize())];
        }

        public int DeckSize()
        {
            return events.Count();
        }
    }
}
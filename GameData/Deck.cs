using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace MonopolyGame
{
    public abstract class Deck
    {
        [JsonProperty("cards")]
        protected List<Card> cards;
        public int deckSize { get { return cards.Count; } }

        [JsonConstructor]
        public Deck(List<Card> cards)
        {
            this.cards = cards;
        }

        public Deck()
        {

        }

        public Card Draw()
        {
            Card drawResult = cards[new Random().Next(deckSize)];
            return drawResult;
        }
    }
}
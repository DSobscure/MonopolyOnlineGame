using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class CardBlock : Block
    {
        [JsonProperty("deck")]
        protected Deck deck { get; set; }

        [JsonConstructor]
        public CardBlock(Deck deck, List<Token> tokens) : base(tokens)
        {
            this.deck = deck;
        }

        public CardBlock(Deck deck) : base()
        {
            this.deck = deck;
        }

        public Card Draw()
        {
            return deck.Draw();
        }
    }
}
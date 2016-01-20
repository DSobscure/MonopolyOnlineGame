using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class DestinyBlock : CardBlock
    {
        [JsonConstructor]
        public DestinyBlock(DestinyDeck destinyDeck, List<Token> tokens) : base(destinyDeck, tokens)
        {

        }

        public DestinyBlock(DestinyDeck destinyDeck) : base(destinyDeck)
        {

        }
    }
}
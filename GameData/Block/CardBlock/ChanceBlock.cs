using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class ChanceBlock : CardBlock
    {
        [JsonConstructor]
        public ChanceBlock(ChanceDeck chanceDeck, List<Token> tokens) : base(chanceDeck, tokens)
        {

        }

        public ChanceBlock(ChanceDeck chanceDeck) : base(chanceDeck)
        {

        }
    }
}
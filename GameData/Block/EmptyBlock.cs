using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class EmptyBlock : Block
    {
        [JsonConstructor]
        public EmptyBlock(List<Token> tokens) : base(tokens)
        {

        }

        public EmptyBlock() : base()
        {

        }
    }
}
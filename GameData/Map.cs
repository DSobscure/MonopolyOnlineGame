using System.Collections.Generic;
using Newtonsoft.Json;

namespace MonopolyGame
{
    public class Map
    {
        [JsonProperty("blocks")]
        public List<Block> blocks { get; protected set; }

        [JsonConstructor]
        public Map(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public Map()
        {

        }

        public void MoveToken(Token token, int steps)
        {
            for (int i = 0; i < steps - 1; i++)
            {
                blocks[token.position].TakeToken(token);
                token.position = (token.position + 1) % blocks.Count;
                blocks[token.position].PassToken(token);
            }
            blocks[token.position].TakeToken(token);
            token.position = (token.position + 1) % blocks.Count;
            blocks[token.position].PlaceToken(token);
        }
    }
}
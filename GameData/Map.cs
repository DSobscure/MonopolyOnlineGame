using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Map
    {
        List<Block> blocks { get; set; }

        public Map(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void MoveToken(Token token, int steps)
        {
            int remainSteps = steps;
            while(remainSteps > 1)
            {
                blocks[token.position].TakeToken(token);
                token.position = (token.position+1)%blocks.Count;
                blocks[token.position].PassToken(token);
            }
            blocks[token.position].TakeToken(token);
            token.position = (token.position + 1) % blocks.Count;
            blocks[token.position].PlaceToken(token);
        }
    }
}
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
            for(int remainSteps = steps; remainSteps > 0; remainSteps--)
            {
                blocks[token.position].TakeToken(token);
                blocks[(token.position+1)% blocks.Count].PlaceToken(token);
                token.position = (token.position+1)%blocks.Count;
            }            
        }
    }
}
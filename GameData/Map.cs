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
            while(remainSteps > 0)
            {
                blocks[token.position].TakeToken(token);
                token.position = (token.position+1)%blocks.Count;
                blocks[token.position].PlaceToken(token);
                blocks[token.position].TrigEvent(token.owner, --remainSteps);
            }            
        }
    }
}
using System.Collections.Generic;

namespace MonopolyGame
{
    public class Map
    {
        public Game game { get; protected set; }
        List<Block> blocks { get; set; }

        public Map(Game game)
        {
            this.game = game;
        }

        public void LoadBlocks(List<Block> blocks)
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
using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Map
    {
        public Game game { get; protected set; }
        public List<Block> blocks { get; protected set; }

        public Map(Game game)
        {
            this.game = game;
        }

        public void RegisterBlocks(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void MoveToken(Token token, int steps)
        {
            for(int i = 0; i < steps-1 ; i++)
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
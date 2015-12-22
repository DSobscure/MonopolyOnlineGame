using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Game
    {
        public Map map { get; protected set; }

        public void MoveToken(Token token, int step)
        {
            map.MoveToken(token, step);
        }
    }
}
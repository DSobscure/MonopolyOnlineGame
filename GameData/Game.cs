using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame
{
    public class Game
    {
        public Map map { get; }
        public List<Block> blocks { get; }
        public List<Player> players { get; }
        public DestinyDeck destinyDeck { get; }
        public ChanceDeck chanceDeck { get; }

        public Game(List<Player> players)
        {
            this.players = players;
            this.destinyDeck = new DestinyDeck();
            this.chanceDeck = new ChanceDeck();
            this.map = new Map(blocks);
            this.blocks = new List<Block>(){
                // 1st street
                new StartBlock(map),
                new LandBlock(new Land(500)),
                new LandBlock(new Land(400)),
                new LandBlock(new Land(200)),
                new ChanceBlock(map),
                new LandBlock(new Land(200)),
                new LandBlock(new Land(400)),
                new LandBlock(new Land(300)),
                // 2nd street
                new EmptyBlock(map),
                new LandBlock(new Land(100)),
                new LandBlock(new Land(200)),
                new LandBlock(new Land(400)),
                new DestinyBlock(map),
                new LandBlock(new Land(300)),
                new LandBlock(new Land(400)),
                new LandBlock(new Land(700)),
                // 3rd street
                new EmptyBlock(map),
                new LandBlock(new Land(500)),
                new LandBlock(new Land(200)),
                new LandBlock(new Land(300)),
                new ChanceBlock(map),
                new LandBlock(new Land(200)),
                new LandBlock(new Land(100)),
                new LandBlock(new Land(100)),
                // 4th street
                new EmptyBlock(map),
                new LandBlock(new Land(200)),
                new LandBlock(new Land(400)),
                new LandBlock(new Land(600)),
                new DestinyBlock(map),
                new LandBlock(new Land(300)),
                new LandBlock(new Land(500)),
                new LandBlock(new Land(800))
            };
        }

        public void MoveToken(Token token, int step)
        {
            map.MoveToken(token, step);
        }
    }
}
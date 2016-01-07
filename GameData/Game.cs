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
            foreach (Player player in players)
            {
                player.RunOutOfMoney += GameOver;
            }
            this.destinyDeck = new DestinyDeck();
            this.chanceDeck = new ChanceDeck();
            this.map = new Map(this, blocks);
            this.blocks = new List<Block>(){
                // 1st street
                new StartBlock(map, 1000),
                new LandBlock(map, new Land(500)),
                new LandBlock(map, new Land(400)),
                new LandBlock(map, new Land(200)),
                new ChanceBlock(map),
                new LandBlock(map, new Land(200)),
                new LandBlock(map, new Land(400)),
                new LandBlock(map, new Land(300)),
                // 2nd street
                new EmptyBlock(map),
                new LandBlock(map, new Land(100)),
                new LandBlock(map, new Land(200)),
                new LandBlock(map, new Land(400)),
                new DestinyBlock(map),
                new LandBlock(map, new Land(300)),
                new LandBlock(map, new Land(400)),
                new LandBlock(map, new Land(700)),
                // 3rd street
                new EmptyBlock(map),
                new LandBlock(map, new Land(500)),
                new LandBlock(map, new Land(200)),
                new LandBlock(map, new Land(300)),
                new ChanceBlock(map),
                new LandBlock(map, new Land(200)),
                new LandBlock(map, new Land(100)),
                new LandBlock(map, new Land(100)),
                // 4th street
                new EmptyBlock(map),
                new LandBlock(map, new Land(200)),
                new LandBlock(map, new Land(400)),
                new LandBlock(map, new Land(600)),
                new DestinyBlock(map),
                new LandBlock(map, new Land(300)),
                new LandBlock(map, new Land(500)),
                new LandBlock(map, new Land(800))
            };
        }

        public void MoveToken(Token token, int step)
        {
            map.MoveToken(token, step);
        }

        public void GameOver()
        {

        }
    }
}
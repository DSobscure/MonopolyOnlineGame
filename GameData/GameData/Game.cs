using System.Collections.Generic;
using System.Linq;
using System;

namespace MonopolyGame
{
    public enum ResponseType
    {
        NoResponse,
        BuyLandSelection,
        UpgradeLandSelection,
        PayForTollMessage,
        CardBlockMessage
    }

    public class Game
    {
        public Map map { get; private set; }
        private Die die;
        public List<Block> blocks { get; private set; }
        public List<Player> players { get; private set; }
        public DestinyDeck destinyDeck { get; private set; }
        public ChanceDeck chanceDeck { get; private set; }
        public bool gameOverFlag;
        public ResponseType response;

        public Game(int startMoney, List<Player> players)
        {
            this.response = ResponseType.NoResponse;
            this.die = new Die();
            this.gameOverFlag = false;
            this.players = players;
            foreach (Player player in players)
            {
                player.JoinGame(this, startMoney);
            }
            this.destinyDeck = new DestinyDeck();
            this.chanceDeck = new ChanceDeck();
            this.map = new Map(this, blocks);
            this.blocks = new List<Block>(){
                // 1st street
                new StartBlock(map, 1000, players),
                new LandBlock(map, new Land(500, "Alpha")),
                new LandBlock(map, new Land(400, "Bravo")),
                new LandBlock(map, new Land(200, "Charlie")),
                new ChanceBlock(map),
                new LandBlock(map, new Land(200, "Delta")),
                new LandBlock(map, new Land(400, "Echo")),
                new LandBlock(map, new Land(300, "Foxtrot")),
                // 2nd street
                new EmptyBlock(map),
                new LandBlock(map, new Land(100, "Golf")),
                new LandBlock(map, new Land(200, "Hotel")),
                new LandBlock(map, new Land(400, "India")),
                new DestinyBlock(map),
                new LandBlock(map, new Land(300, "Juliet")),
                new LandBlock(map, new Land(400, "Kilo")),
                new LandBlock(map, new Land(700, "Lima")),
                // 3rd street
                new EmptyBlock(map),
                new LandBlock(map, new Land(500, "Mike")),
                new LandBlock(map, new Land(200, "November")),
                new LandBlock(map, new Land(300, "Oscar")),
                new ChanceBlock(map),
                new LandBlock(map, new Land(200, "Papa")),
                new LandBlock(map, new Land(100, "Quebec")),
                new LandBlock(map, new Land(100, "Romeo")),
                // 4th street
                new EmptyBlock(map),
                new LandBlock(map, new Land(200, "Sierra")),
                new LandBlock(map, new Land(400, "Tango")),
                new LandBlock(map, new Land(600, "Uniform")),
                new DestinyBlock(map),
                new LandBlock(map, new Land(300, "Victor")),
                new LandBlock(map, new Land(500, "Whiskey")),
                new LandBlock(map, new Land(800, "X-ray"))
            };
        }

        public void MoveToken(Token token, int step)
        {
            map.MoveToken(token, step);
        }

        public void SetGameOverFlag()
        {
            gameOverFlag = true;
        }

        public int RollDice()
        {
            return die.roll;
        }

        public Player GameOverReturnWinnner()
        {
            int money = 0;
            Player winner = null;
            foreach (Player player in players)
            {
                if (player.money > money)
                {
                    money = player.money;
                    winner = player;
                }
                player.LeaveGame();
            }

            return winner;
        }
    }
}
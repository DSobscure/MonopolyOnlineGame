using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;

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
        [JsonProperty("map")]
        public Map map { get; private set; }
        protected Die die;
        [JsonProperty("players")]
        public List<Player> players { get; private set; }
        public DestinyDeck destinyDeck { get; private set; }
        public ChanceDeck chanceDeck { get; private set; }
        [JsonProperty("gameOverFlag")]
        public bool gameOverFlag;
        [JsonProperty("turnCounter")]
        public int turnCounter { get; protected set; }
        [JsonProperty("canRollDice")]
        public bool canRollDice { get; set; }


        [JsonConstructor]
        public Game(Map map, List<Player> players, bool gameOverFlag, int turnCounter, bool canRollDice)
        {
            this.map = map;
            this.die = new Die();
            this.players = players;
            this.destinyDeck = new DestinyDeck();
            this.chanceDeck = new ChanceDeck();
            this.gameOverFlag = gameOverFlag;
            this.turnCounter = turnCounter;
            this.canRollDice = canRollDice;
        }
        public Game(int startMoney, List<Player> players)
        {
            turnCounter = 0;
            this.die = new Die();
            this.gameOverFlag = false;
            this.players = players;
            foreach (Player player in players)
            {
                player.JoinGame(this, startMoney);
            }
            this.destinyDeck = new DestinyDeck();
            this.chanceDeck = new ChanceDeck();
            map = new Map(new List<Block>(){
                // 1st street
                new StartBlock(1000, players),
                new LandBlock(new Land(500, "Alpha")),
                new LandBlock(new Land(400, "Bravo")),
                new LandBlock(new Land(200, "Charlie")),
                new ChanceBlock(chanceDeck),
                new LandBlock(new Land(200, "Delta")),
                new LandBlock(new Land(400, "Echo")),
                new LandBlock(new Land(300, "Foxtrot")),
                // 2nd street
                new EmptyBlock(),
                new LandBlock(new Land(100, "Golf")),
                new LandBlock(new Land(200, "Hotel")),
                new LandBlock(new Land(400, "India")),
                new DestinyBlock(destinyDeck),
                new LandBlock(new Land(300, "Juliet")),
                new LandBlock(new Land(400, "Kilo")),
                new LandBlock(new Land(700, "Lima")),
                // 3rd street
                new EmptyBlock(),
                new LandBlock(new Land(500, "Mike")),
                new LandBlock(new Land(200, "November")),
                new LandBlock(new Land(300, "Oscar")),
                new ChanceBlock(chanceDeck),
                new LandBlock(new Land(200, "Papa")),
                new LandBlock(new Land(100, "Quebec")),
                new LandBlock(new Land(100, "Romeo")),
                // 4th street
                new EmptyBlock(),
                new LandBlock(new Land(200, "Sierra")),
                new LandBlock(new Land(400, "Tango")),
                new LandBlock(new Land(600, "Uniform")),
                new DestinyBlock(destinyDeck),
                new LandBlock(new Land(300, "Victor")),
                new LandBlock(new Land(500, "Whiskey")),
                new LandBlock(new Land(800, "X-ray"))
            });
        }

        public void MoveToken(Token token, int steps)
        {
            map.MoveToken(token, steps);
        }

        public virtual void SetGameOverFlag()
        {
            gameOverFlag = true;
        }

        public int RollDice()
        {
            canRollDice = false;
            return die.roll;
        }

        public Player GameOverReturnWinnner()
        {
            int maxMoney = players.Max(x => x.money);
            return players.First(player=>player.money == maxMoney);
        }

        public virtual Game Serialize()
        {
            return null;
        }

        public void EndTurn()
        {
            turnCounter++;
            canRollDice = true;
        }
    }
}
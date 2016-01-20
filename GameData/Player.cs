using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    //=============================================================
    // Player class
    //   Save a players information and reset after joined a game.
    //=============================================================
    public class Player
    {
        // Attributes //
        [JsonProperty("id")]
        public int id { get; private set; }
        [JsonProperty("username")]
        public string username { get; private set; }
        [JsonProperty("token")]
        public Token token { get; protected set; }
        private int _money;
        [JsonProperty("money")]
        public virtual int money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }
        [JsonProperty("landList")]
        public List<Land> landList { get; protected set; }
        [JsonProperty("inGame")]
        public bool inGame { get; protected set; }

        // Functions //
        [JsonConstructor]
        public Player(int id, string username, Token token, int money, List<Land> landList, bool inGame)
        {
            this.id = id;
            this.username = username;
            this.token = token;
            this.money = money;
            this.landList = landList;
            this.inGame = inGame;
        }
        public Player(int id, string username)
        {
            this.id = id;
            this.username = username;
            this.token = new Token(username);
            this.landList = new List<Land>();
        }

        public virtual void Move(int steps)
        {
            
        }

        public virtual void JoinGame(Game game, int startMoney)
        {
            money = startMoney;
            inGame = true;
        }

        public virtual void LeaveGame()
        {
            inGame = false;
            landList.Clear();
        }

        public virtual Player Serialize()
        {
            return null;
        }
    }
}
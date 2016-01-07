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
        public int id { get; }
        public string username { get; }
        public Token token { get; protected set; }
        private int _money;
        public int money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                if (money <= 0 && RunOutOfMoney != null)
                    RunOutOfMoney();
            }
        }
        public List<Land> landList { get; protected set; }
        public bool inGame { get; protected set; }
        public Game playingGame { get; protected set; }
        public event Action RunOutOfMoney;

        // Functions //
        public Player(int id, string username)
        {
            this.id = id;
            this.username = username;
            this.token = new Token(this);
            this.landList = new List<Land>();
        }

        public void Move(int steps)
        {
            playingGame.MoveToken(token, steps);
        }
    }
}
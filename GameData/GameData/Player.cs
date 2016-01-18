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
        public int id { get; private set; }
        public string username { get; private set; }
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
                if (money <= 0)
                    playingGame.SetGameOverFlag();
            }
        }
        public List<Land> landList { get; protected set; }
        public bool inGame { get; protected set; }
        public Game playingGame { get; protected set; }
        //public event Action RunOutOfMoney;

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

        public void JoinGame(Game game, int startMoney)
        {
            playingGame = game;
            money = startMoney;
            inGame = true;
        }

        public void LeaveGame()
        {
            inGame = false;
            playingGame = null;
            landList.Clear();
        }
    }
}
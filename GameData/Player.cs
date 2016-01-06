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
        public int money { get; set; }
        public List<Land> landList { get; protected set; }
        public bool inGame { get; protected set; }
        public Game playingGame { get; protected set; }

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
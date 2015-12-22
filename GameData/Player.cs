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
        private int id { get; }
        private string username { get; }
        private Token token { get; protected set; }
        public int money { get; set; }
        public List<Land> landList { get; protected set; }
        public bool inGame { get; set; }

        // Functions //
        protected Player(string username)
        {
            this.id = Lobby.GetNewUserId();
            this.username = username;
            this.token = new Token(this);
            this.landList = new List<Land>();
        }

        public void ResetInGameData(Map map)
        {
            this.money = 0;
            this.landList.Clear();
            this.token.Reset(map);
        }

        public void Move(int steps)
        {
            this.token.Move(steps);
        }
    }
}
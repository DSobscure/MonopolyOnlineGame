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
        private MonopolyGame::Token token { get; protected set; }
        public int money { get; set; }
        public List<int> landIdList { get; protected set; }
        public bool inGame { get; set; }

        // Functions //
        protected Player( string username )
        {
            this.id = MonopolyGame::Lobby.GetNewUserId();
            this.username = username;
            this.token = new Monopoly::Token( this.id );
            this.landIdList = new List<int>();
        }

        public void ResetInGameData( int mapId )
        {
            this.money = 0;
            this.landList.Clear();
            this.token.Reset( mapId );
        }

        public void Move()
        {
            this.token.Move();
        }
    }
}
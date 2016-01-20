using MonopolyGame;
using System;
using System.Collections.Generic;

namespace MonopolyServer
{
    public class ServerGame : Game
    {
        private static int serverGameCounter = 0;
        public List<ServerUser> users { get; protected set; }
        public int id { get; protected set; }
        public event Action<ServerGame> OnGameOver;

        public ServerGame(int startMoney, List<Player> players, List<ServerUser> users) : base(startMoney, players)
        {
            this.users = users;
            serverGameCounter++;
            id = serverGameCounter;
        }

        public override Game Serialize()
        {
            List<Player> playerList = new List<Player>();
            foreach(Player player in players)
            {
                playerList.Add(player.Serialize());
            }
            return new Game(map, playerList, gameOverFlag, turnCounter, canRollDice);
        }

        public override void SetGameOverFlag()
        {
            base.SetGameOverFlag();
            if (OnGameOver != null)
                OnGameOver(this);
        }
    }
}

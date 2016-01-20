using MonopolyGame;
using Newtonsoft.Json;

namespace MonopolyServer
{
    public class ServerPlayer : Player
    {
        [JsonIgnore]
        public Game playingGame { get; protected set; }
        public override int money
        {
            get
            {
                return base.money;
            }

            set
            {
                base.money = value;
                if (base.money <= 0)
                    playingGame.SetGameOverFlag();
            }
        }


        public ServerPlayer(int id, string username) : base(id, username)
        {
        }

        public override void Move(int steps)
        {
            base.Move(steps);
            playingGame.MoveToken(token, steps);
        }
        public override void JoinGame(Game game, int startMoney)
        {
            base.JoinGame(game, startMoney);
            playingGame = game;
        }
        public override void LeaveGame()
        {
            base.LeaveGame();
            playingGame = null;
        }
        public override Player Serialize()
        {
            return new Player(id, username, token, money, landList, inGame);
        }
    }
}

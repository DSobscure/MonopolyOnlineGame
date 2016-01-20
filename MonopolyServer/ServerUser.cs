using OnlineGameDataStructure;
using MonopolyGame;

namespace MonopolyServer
{
    public class ServerUser : User
    {
        public Peer Peer { get; set; }
        public UserGroup userGroup { get; protected set; }
        public Game playingGame;
        public ServerPlayer player;

        public ServerUser(string userName, bool ready, Peer peer) : base(userName, ready)
        {
            Peer = peer;
        }

        public void MoveToUserGroup(UserGroup userGroup)
        {
            if (this.userGroup != null)
                this.userGroup.UserExit(this);
            this.userGroup = userGroup;
            if (this.userGroup != null)
                this.userGroup.UserEnter(this);
        }

        public override User Serialize()
        {
            return new User(userName, ready);
        }
    }
}

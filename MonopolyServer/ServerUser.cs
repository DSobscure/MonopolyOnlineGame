using OnlineGameDataStructure;

namespace MonopolyServer
{
    class ServerUser : User
    {
        public Peer Peer { get; set; }
        public ServerUserGroup userGroup { get; protected set; }

        public ServerUser(string userName, Peer peer) : base(userName)
        {
            Peer = peer;
        }

        public void MoveToUserGroup(UserGroup userGroup)
        {
            if (this.userGroup != null)
                this.userGroup.UserExit(this);
            this.userGroup = userGroup as ServerUserGroup;
            if (this.userGroup != null)
                this.userGroup.UserEnter(this);
        }

        public override User Serialize()
        {
            return new User(userName);
        }
    }
}

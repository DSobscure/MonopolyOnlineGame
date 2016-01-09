using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameDataStructure
{
    public class Lobby : UserGroup
    {

        public Lobby() : base()
        {
        }

        public void UserEnter(User user)
        {
            Users.Add(user.UserName, user);
            user.UserGroup = this;
        }

        public void UserExit(User user)
        {
            Users.Remove(user.UserName);
            user.UserGroup = null;
        }
    }
}

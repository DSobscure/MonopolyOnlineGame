using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineGameDataStructure;

namespace MonopolyServer
{
    class ServerUserGroup : UserGroup
    {
        public override void UserEnter(User user)
        {
            base.UserEnter(user);
            (user as ServerUser).MoveToUserGroup(this);
        }

        public override void UserExit(User user)
        {
            base.UserExit(user);
            (user as ServerUser).MoveToUserGroup(null);
        }
    }
}

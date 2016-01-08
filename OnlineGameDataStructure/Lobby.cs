using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameDataStructure
{
    public class Lobby
    {
        public Dictionary<string,User> Users { get; protected set; }

        public Lobby()
        {
            Users = new Dictionary<string, User>();
        }

        public void UserEnter(User user)
        {
            Users.Add(user.UserName, user);
        }

        public void UserExit(User user)
        {
            Users.Remove(user.UserName);
        }
    }
}

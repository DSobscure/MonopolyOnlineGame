using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameDataStructure
{
    public abstract class UserGroup
    {
        public Dictionary<string, User> Users { get; protected set; }

        protected UserGroup()
        {
            Users = new Dictionary<string, User>();
        }
    }
}

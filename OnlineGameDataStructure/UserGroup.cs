using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlineGameDataStructure
{
    public abstract class UserGroup
    {
        [JsonProperty("users")]
        public Dictionary<string, User> users { get; protected set; }

        protected UserGroup()
        {
            users = new Dictionary<string, User>();
        }

        [JsonConstructor]
        protected UserGroup(Dictionary<string, User> users)
        {
            this.users = users;
        }

        public virtual void UserEnter(User user)
        {
            users.Add(user.userName, user);
        }

        public virtual void UserExit(User user)
        {
            users.Remove(user.userName);
        }
    }
}

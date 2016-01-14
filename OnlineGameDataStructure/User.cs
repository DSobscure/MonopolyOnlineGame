using Newtonsoft.Json;

namespace OnlineGameDataStructure
{
    public class User
    {
        [JsonProperty("userName")]
        public string userName { get; protected set; }

        [JsonConstructor]
        public User(string userName)
        {
            this.userName = userName;
        }

        public virtual User Serialize()
        {
            return null;
        }
    }
}

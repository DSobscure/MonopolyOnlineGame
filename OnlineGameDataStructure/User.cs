using Newtonsoft.Json;

namespace OnlineGameDataStructure
{
    public class User
    {
        [JsonProperty("userName")]
        public string userName { get; protected set; }
        [JsonProperty("ready")]
        public bool ready { get; set; }

        [JsonConstructor]
        public User(string userName, bool ready)
        {
            this.userName = userName;
            this.ready = ready;
        }

        public virtual User Serialize()
        {
            return null;
        }
    }
}

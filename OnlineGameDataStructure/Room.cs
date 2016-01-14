using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlineGameDataStructure
{
    public class Room : UserGroup
    {
        [JsonProperty("host")]
        public User host { get; protected set; }
        [JsonProperty("id")]
        public int id { get; protected set; }
        [JsonProperty("name")]
        public string name { get; protected set; }
        [JsonProperty("isEncrypted")]
        public bool isEncrypted { get; protected set; }
        [JsonProperty("password")]
        public string password { get; protected set; }

        public Room(User host, string name, bool isEncrypted, string password) : base()
        {
            this.host = host;
            this.name = name;
            this.isEncrypted = isEncrypted;
            this.password = password;
        }

        [JsonConstructor]
        public Room(User host, int id, string name, bool isEncrypted, string password, Dictionary<string, User> users) : base(users)
        {
            this.host = host;
            this.id = id;
            this.name = name;
            this.isEncrypted = isEncrypted;
            this.password = password;
        }

        public virtual Room Serialize()
        {
            return null;
        }
    }
}

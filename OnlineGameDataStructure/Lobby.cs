using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlineGameDataStructure
{
    public class Lobby : UserGroup
    {
        [JsonProperty("rooms")]
        public Dictionary<int, Room> rooms { get; set; }

        public Lobby() : base()
        {
            rooms = new Dictionary<int, Room>();
        }

        [JsonConstructor]
        public Lobby(Dictionary<string, User> users, Dictionary<int, Room> rooms) : base(users)
        {
            this.rooms = rooms;
        }

        public virtual Lobby Serialize()
        {
            return null;
        }
    }
}

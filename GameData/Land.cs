using Newtonsoft.Json;

namespace MonopolyGame
{
    //enum LandStatus { Empty, House1, House2, House3, Hotel }
    public class Land
    {
        [JsonProperty("ownerName")]
        public string ownerName { get; private set; }
        [JsonProperty("level")]
        public int level { get; private set; }
        [JsonProperty("tollBase")]
        public int tollBase { get; private set; }
        private const int maxLevel = 5;
        public bool isUpgradable { get { return this.level < maxLevel; } }
        public int toll { get { return this.level * this.tollBase; } }
        public int price { get { return tollBase * 10; } }
        [JsonProperty("name")]
        public string name { get; private set; }

        [JsonConstructor]
        public Land(string ownerName, int level, int tollBase, string name)
        {
            this.ownerName = ownerName;
            this.level = level;
            this.tollBase = tollBase;
            this.name = name;
        }
        public Land( int tollBase, string name )
        {
            this.ownerName = null;
            this.level = 1;
            this.tollBase = tollBase;
            this.name = name;
        }

        public void Buy(Player player)
        {
            player.money -= price;
            ownerName = player.username;
            player.landList.Add(this);
        }

        public bool Upgrade(Player owner)
        {
            if(isUpgradable)
            {
                owner.money -= tollBase;
                level += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PayToll(Player player, Player owner)
        {
            player.money -= toll;
            owner.money += toll;
        }
    }
}
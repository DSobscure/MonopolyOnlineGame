namespace MonopolyGame
{
    //enum LandStatus { Empty, House1, House2, House3, Hotel }
    public class Land
    {
        public Player owner { get; private set; }
        public int level { get; private set; }
        public int tollBase { get; private set; }
        private const int maxLevel = 5;
        public bool isUpgradable { get { return this.level < maxLevel; } }
        public int toll { get { return this.level * this.tollBase; } }
        public int price { get { return tollBase * 10; } }
        public string name { get; private set; }

        public Land( int tollBase, string name )
        {
            this.owner = null;
            this.level = 1;
            this.tollBase = tollBase;
            this.name = name;
        }

        public void Buy(Player player)
        {
            player.money -= price;
            owner = player;
            player.landList.Add(this);
        }

        public void Upgrade()
        {
            level += 1;
        }
    }
}
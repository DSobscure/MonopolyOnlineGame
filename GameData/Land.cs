namespace MonopolyGame
{
    //enum LandStatus { Empty, House1, House2, House3, Hotel }
    public class Land
    {
        public Player owner { get; private set; }
        public int level { get; private set; }
        public int tollBase { get; }
        private const int maxLevel = 5;

        public Land( int tollBase )
        {
            this.owner = null;
            this.level = 1;
            this.tollBase = tollBase;
        }

        public int Toll()
        {
            return this.level * this.tollBase;
        }

        public void Upgrade()
        {
            this.level += 1;
        }

        public bool Upgradable()
        {
            return this.level < maxLevel;
        }
    }
}
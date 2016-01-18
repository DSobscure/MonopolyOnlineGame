using System;

namespace MonopolyGame
{
    public class LandBlock : Block
    {
        public Land land { get; set; }
        public event Action<Player,Land> OnBuyLandSelection;
        public event Action<Player,Land> OnUpgradeLandSelection;
        public event Action<Player,Player,int> OnPayForToll;

        public LandBlock(Map map, Land land) : base(map)
        {
            this.land = land;
        }
    }
}
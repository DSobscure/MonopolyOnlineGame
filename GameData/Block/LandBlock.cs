using System;

namespace MonopolyGame
{
    public class LandBlock : Block
    {
        public Land land { get; }
        public event Action OnBuyLandSelection;
        public event Action OnUpgradeLandSelection;
        public event Action OnPayForToll;

        public LandBlock(Land land)
        {
            this.land = land;
        }

        protected override void Place(Player player)
        {
            this.Event(player);
        }

        protected override void Event(Player player)
        {
            if (this.land.owner == null)
            {
                if (OnBuyLandSelection != null && OnBuyLandSelection())
                {
                    this.land.Buy(player);
                }
            }
            else if (this.land.owner == player)
            {
                if (this.land.Upgradable && OnUpgradeLandSelection != null && OnUpgradeLandSelection())
                {
                    this.land.Upgrade();
                }
            }
            else
            {
                this.land.PayForToll(player);
                if (OnPayForToll != null)
                    OnPayForToll();
            }
        }
    }
}
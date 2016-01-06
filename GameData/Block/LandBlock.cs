using System;

namespace MonopolyGame
{
    public class LandBlock : Block
    {
        public Land land { get; }
        public event Action<Player,Land> OnBuyLandSelection;
        public event Action<Player,Land> OnUpgradeLandSelection;
        public event Action<Player,Player,int> OnPayForToll;

        public LandBlock(Map map, Land land) : base(map)
        {
            this.land = land;
            OnTokenPlaceInto += BuyLandSelectionEventTask;
            OnTokenPlaceInto += UpgradeLandSelectionEventTask;
            OnTokenPlaceInto += PayForTollEventTask;
        }

        private void BuyLandSelectionEventTask(Token token)
        {
            if (land.owner == null)
            {
                if (OnBuyLandSelection != null)
                    OnBuyLandSelection(token.owner, land);
            }
        }
        private void UpgradeLandSelectionEventTask(Token token)
        {
            if (land.owner == token.owner)
            {
                if (land.isUpgradable && (OnUpgradeLandSelection != null))
                {
                    OnUpgradeLandSelection(token.owner, land);
                }
            }
        }
        private void PayForTollEventTask(Token token)
        {
            if (land.owner != null && land.owner != token.owner)
            {
                if (OnPayForToll != null)
                    OnPayForToll(token.owner, land.owner, land.toll);
            }
        }
    }
}
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
            OnTokenPlaceInto += BuyLandSelectionEventTask;
            OnTokenPlaceInto += UpgradeLandSelectionEventTask;
            OnTokenPlaceInto += PayForTollEventTask;
        }

        private void BuyLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner == null)
            {
                if (landBlock.OnBuyLandSelection != null)
                    landBlock.OnBuyLandSelection(token.owner, land);
                //map.game.response = ResponseType.BuyLandSelection;
            }
        }
        private void UpgradeLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner == token.owner)
            {
                if (landBlock.land.isUpgradable && (landBlock.OnUpgradeLandSelection != null))
                    landBlock.OnUpgradeLandSelection(token.owner, land);
                //map.game.response = ResponseType.UpgradeLandSelection;
            }
        }
        private void PayForTollEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner != null && landBlock.land.owner != token.owner)
            {
                if (landBlock.OnPayForToll != null)
                    landBlock.OnPayForToll(token.owner, land.owner, land.toll);
                //map.game.response = ResponseType.PayForTollMessage;
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class CardBlock : Block
    {
        protected Deck deck { get; set; }

        public CardBlock(Map map, Deck deck) : base(map)
        {
            this.deck = deck;
            OnTokenPlaceInto += DrawCardEventTask;
        }

        private void DrawCardEventTask(Block block, Token token)
        {
            CardBlock cardBlock = block as CardBlock;
            ExecutedCard(token.owner, cardBlock.deck.Draw());
        }

        private void ExecutedCard(Player player, Card card)
        {
            List<Player> allPlayers = this.map.game.players;
            switch (card.type)
            {
                case CardType.GainMoney:
                    player.money += card.value;
                    break;
                case CardType.LoseMoney:
                    player.money -= card.value;
                    break;
                case CardType.StealMoney:
                    foreach (Player victim in allPlayers)
                    {
                        victim.money -= card.value;
                    }
                    player.money += card.value * allPlayers.Count;
                    break;
                case CardType.ReleaseMoney:
                    foreach (Player victim in allPlayers)
                    {
                        victim.money += card.value;
                    }
                    player.money -= card.value * allPlayers.Count;
                    break;
            }
        }
    }
}
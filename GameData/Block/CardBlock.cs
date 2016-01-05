using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class CardBlock : Block
    {
        protected Deck deck { get; }

        protected override void Place(Player player)
        {
            this.Event(player);
        }

        protected override void Event(Player player)
        {
            this.ExecuteCard(player, deck.Draw());
        }

        private void ExecutedCard(Player player, Card card)
        {
            switch (card.type)
            {
                case CardType.GainMoney:
                    player.money += card.value;
                    break;
                case CardType.LoseMoney:
                    player.money -= card.value;
                    break;
                case CardType.StealMoney:
                    List<Player> allPlayers = this.map.game.players;
                    foreach (int victim in allPlayers)
                    {
                        victim.money -= card.value;
                    }
                    player.money += card.value * allPlayers.Count;
                    break;
                case CardType.ReleaseMoney:
                    List<Player> allPlayers = this.map.game.players;
                    foreach (int victim in allPlayers)
                    {
                        victim.money += card.value;
                    }
                    player.money -= card.value * allPlayers.Count;
                    break;
            }
        }
    }
}
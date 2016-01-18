using System.Collections.Generic;

namespace MonopolyGame
{
    public class ChanceDeck : Deck
    {
        public ChanceDeck()
        {
            cards = new List<Card>()
            {
                new Card(CardType.GainMoney, 100),
                new Card(CardType.GainMoney, 100),
                new Card(CardType.GainMoney, 100),
                new Card(CardType.GainMoney, 300),
                new Card(CardType.GainMoney, 300),
                new Card(CardType.GainMoney, 500),
                new Card(CardType.GainMoney, 500),
                new Card(CardType.StealMoney, 100),
                new Card(CardType.StealMoney, 300),
                new Card(CardType.StealMoney, 300),
                new Card(CardType.LoseMoney, 2000)
            };
        }
    }
}
namespace MonopolyGame
{
    public class DestinyDeck : Deck
    {
        public DestinyDeck()
        {
            cards = new List<Card>()
            {
                new Card(CardType.LoseMoney, 200),
                new Card(CardType.LoseMoney, 200),
                new Card(CardType.LoseMoney, 200),
                new Card(CardType.LoseMoney, 400),
                new Card(CardType.LoseMoney, 400),
                new Card(CardType.LoseMoney, 800),
                new Card(CardType.ReleaseMoney, 200),
                new Card(CardType.ReleaseMoney, 200),
                new Card(CardType.ReleaseMoney, 400),
                new Card(CardType.GainMoney, 1000),
                new Card(CardType.GainMoney, 2000)
            };
        }
    }
}
using System;

namespace MonopolyGame
{
    public enum CardType { GainMoney, LoseMoney, StealMoney, ReleaseMoney }
    public class Card
    {
        public CardType type { get; private set; }
        public int value { get; private set; }

        public Card(CardType type, int value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
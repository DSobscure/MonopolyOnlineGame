using System;

namespace MonopolyGame
{
    public enum CardType { GainMoney, LoseMoney, StealMoney, ReleaseMoney }
    public class Card
    {
        public CardType type { get; }
        public int value { get; }

        public Card(CardType type, int value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
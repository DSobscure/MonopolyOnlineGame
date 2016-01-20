using Newtonsoft.Json;

namespace MonopolyGame
{
    public enum CardType { GainMoney, LoseMoney, StealMoney, ReleaseMoney }
    public class Card
    {
        [JsonProperty("type")]
        public CardType type { get; private set; }
        [JsonProperty("value")]
        public int value { get; private set; }

        [JsonConstructor]
        public Card(CardType type, int value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
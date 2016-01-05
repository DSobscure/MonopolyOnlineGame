
namespace MonopolyGame
{
    public class ChanceBlock : Block
    {
        private ChanceDeck deck { get; }

        public ChanceBlock()
        {
            deck = new ChanceDeck();
        }

        private override void Event(Player player)
        {
            deck.DrawAndExecute(player);
        }
    }
}
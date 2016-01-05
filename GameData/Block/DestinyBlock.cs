
namespace MonopolyGame
{
    public class DestinyBlock : Block
    {
        private DestinyDeck deck { get; }

        public DestinyBlock()
        {
            deck = new DestinyDeck();
        }

        private override void Event(Player player)
        {
            deck.DrawAndExecute(player);
        }
    }
}
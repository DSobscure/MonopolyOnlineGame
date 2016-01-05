namespace MonopolyGame
{
    public class StartBlock : Block
    {
        public int salary { get; private set; }

        public StartBlock(int salary)
        {
            this.salary = salary;
        }

        public override void TrigEvent(Player player, int remainSteps)
        {
            if (remainSteps > 0)
                this.Event(player);
        }

        private override void Event(Player player)
        {
            player.money += salary;
        }
    }
}
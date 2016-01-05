using System;

namespace MonopolyGame
{
    public class StartBlock : Block
    {
        public int salary { get; private set; }
        public event Action OnPassStartBlock;

        public StartBlock(int salary)
        {
            this.salary = salary;
        }

        public override void Pass(Player player)
        {
            this.Event(player);
        }

        protected override void Event(Player player)
        {
            player.money += salary;
            if (OnPassStartBlock != null)
                OnPassStartBlock();
        }
    }
}
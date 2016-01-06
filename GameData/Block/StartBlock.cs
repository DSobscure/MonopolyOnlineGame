using System;

namespace MonopolyGame
{
    public class StartBlock : Block
    {
        public int salary { get; private set; }

        public StartBlock(Map map, int salary) : base(map)
        {
            this.salary = salary;
            OnTokenPass += PassStartBlockEventTask;
        }

        private void PassStartBlockEventTask(Token token)
        {
            token.owner.money += salary;
        }
    }
}
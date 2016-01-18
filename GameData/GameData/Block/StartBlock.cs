using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class StartBlock : Block
    {
        public int salary { get; private set; }

        public StartBlock(Map map, int salary, List<Player> players) : base(map)
        {
            this.salary = salary;
            foreach (Player player in players)
            {
                this.tokens.Add(player.token);
                player.token.position = 0;
            }
            OnTokenPass += PassStartBlockEventTask;
        }

        private void PassStartBlockEventTask(Block block, Token token)
        {
            StartBlock startBlock = block as StartBlock;
            token.owner.money += startBlock.salary;
        }
    }
}
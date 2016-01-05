using System;

namespace MonopolyGame
{
    public class Die
    {
        private Random rand { get; }

        public Die()
        {
            this.rand = new Random();
        }

        public int RollDie()
        {
            return this.rand.Next(1, 6);
        }
    }
}
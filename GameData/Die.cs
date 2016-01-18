using System;

namespace MonopolyGame
{
    public class Die
    {
        public int roll
        {
            get
            {
                return new Random().Next(1, 6);
            }
        }

        public Die()
        {
            
        }
    }
}
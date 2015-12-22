using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using MonopolyGame;

namespace MonopolyGame
{
    //=============================================================
    // Token class
    //   Use for controling a player's position.
    //=============================================================
    public class Token
    {
        // Attributes //
        public Player owner { get; }
        public Map map { get; set; }
        public Block position { get; set; }
        public int stepsLeft { get; set; }

        // Functions //
        protected Token(Player owner)
        {
            this.owner = owner;
            this.stepsLeft = 0;
        }

        public void Move(int steps)
        {
            Block newPosition;
            this.stepsLeft = steps;
            while (this.stepsLeft-- > 0)
            {
                newPosition = map.NextBlock(this.position);
                this.MovingAction(this.position, newPosition);
                this.position = newPosition;
                this.position.Trig(this.stepsLeft);
            }
        }

        public void MovingAction(Block departure, Block destination)
        {

        }
    }
}
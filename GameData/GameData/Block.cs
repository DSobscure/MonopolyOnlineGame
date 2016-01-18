using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public abstract class Block
    {
        public List<Token> tokens { get; protected set; }
        protected Map map { get; set; }
        public event Action<Block, Token> OnTokenPlaceInto;
        public event Action<Block, Token> OnTokenPass;
        public event Action<Block, Token> OnTokenTakeLeave;

        protected Block(Map map)
        {
            this.map = map;
            tokens = new List<Token>();
        }

        public void PlaceToken(Token token)
        {
            tokens.Add(token);
            if (OnTokenPlaceInto != null)
                OnTokenPlaceInto(this, token);
        }

        public void PassToken(Token token)
        {
            if (OnTokenPass != null)
                OnTokenPass(this, token);
        }

        public void TakeToken(Token token)
        {
            tokens.Remove(token);
            if (OnTokenTakeLeave != null)
                OnTokenTakeLeave(this, token);
        }
    }
}
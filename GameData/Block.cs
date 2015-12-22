using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public abstract class Block
    {
        public List<Token> tokens { get; protected set; }
        public event Action OnTokenEnter;
        public event Action OnTokenLeave;

        protected Block()
        {
            tokens = new List<Token>();
        }

        public void PlaceToken(Token token)
        {
            tokens.Add(token);
            if (OnTokenEnter != null)
                OnTokenEnter();
        }

        public void TakeToken(Token token)
        {
            tokens.Remove(token);
            if (OnTokenLeave != null)
                OnTokenLeave();
        }
    }
}
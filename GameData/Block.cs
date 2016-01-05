using System;
using System.Collections.Generic;

namespace MonopolyGame
{
    public abstract class Block
    {
        public List<Token> tokens { get; protected set; }
        protected Map map { get; }
        public event Action OnTokenEnter;
        public event Action OnTokenPass;
        public event Action OnTokenLeave;

        protected Block(Map map)
        {
            this.map = map;
            tokens = new List<Token>();
        }

        public void PlaceToken(Token token)
        {
            tokens.Add(token);
            if (OnTokenEnter != null)
                OnTokenEnter();
            this.Place(token.owner);
        }

        public void PassToken(Token token)
        {
            if (OnTokenPass != null)
                OnTokenPass();
            this.Pass(token.owner);
        }

        public void TakeToken(Token token)
        {
            tokens.Remove(token);
            if (OnTokenLeave != null)
                OnTokenLeave();
        }

        protected virtual void Place(Player player) { return; }

        protected virtual void Pass(Player player) { return; }

        protected virtual void Event(Player player) { return; }
    }
}
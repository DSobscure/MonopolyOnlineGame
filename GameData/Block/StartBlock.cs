using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonopolyGame
{
    public class StartBlock : Block
    {
        [JsonProperty("salary")]
        public int salary { get; private set; }

        [JsonConstructor]
        public StartBlock(int salary, List<Token> tokens) : base(tokens)
        {
            this.salary = salary;
        }

        public StartBlock(int salary, List<Player> players) : base()
        {
            this.salary = salary;
            foreach (Player player in players)
            {
                this.tokens.Add(player.token);
                player.token.position = 0;
            }
        }
    }
}
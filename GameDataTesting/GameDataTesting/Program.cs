using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyGame;

namespace GameDataTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players =  new List<Player>()
                                    {
                                        new Player(0,"player1"),
                                        new Player(1,"player2")
                                    };
            Game game = new Game(20000, players);
            foreach(Block block in game.map.blocks)
            {
                block.OnTokenPlaceInto += TokenInto;
            }
            Console.WriteLine("Game start....");
            string cmd;
            int steps, response;
            while(!game.gameOverFlag)
            {
                foreach(Player player in game.players)
                {
                    Console.WriteLine(player.username+"'s turn. input roll to roll a dice");
                    while ((cmd = Console.ReadLine()) != "roll")
                    {
                        switch (cmd)
                        {
                            case "status":
                                {
                                    PrintPlayerData(player);
                                    break;
                                }
                            case "all":
                                {
                                    PrintAllPlayer(players);
                                    break;
                                }
                        }
                    }
                    steps = game.RollDice();
                    Console.WriteLine("move {0} steps",steps);
                    player.Move(steps);
                }
            }
        }

        private static void PrintAllPlayer(List<Player> players)
        {
            foreach(Player player in players)
            {
                PrintPlayerData(player);
            }
        }

        private static void PrintPlayerData(Player player)
        {
            Console.WriteLine("Name: " + player.username);
            Console.WriteLine("Money: " + player.money);
            Console.Write("Land: ");
            foreach (Land land in player.landList)
            {
                Console.Write(land.name + ", ");
            }
            Console.Write("\n");
        }

        private static void TokenInto(Block block, Token token)
        {
            Console.WriteLine(token.owner.username+"go into "+token.position);
            Console.WriteLine("this block is"+block.GetType());
        }
    }
}

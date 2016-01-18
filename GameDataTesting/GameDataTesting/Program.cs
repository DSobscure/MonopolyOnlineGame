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
                    player.Move(steps);
                }
            }
        }

        private static void PrintAllPlayer(List<Player> players)
        {
            throw new NotImplementedException();
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
    }
}

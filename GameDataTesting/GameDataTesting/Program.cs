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
        static Game game;
        static void Main(string[] args)
        {
            List<Player> players =  new List<Player>()
                                    {
                                        new Player(0,"player1"),
                                        new Player(1,"player2")
                                    };
            game = new Game(20000, players);
            foreach(Block block in game.map.blocks)
            {
                block.OnTokenPlaceInto += TokenInto;
                if(block is LandBlock)
                {
                    block.OnTokenPlaceInto += BuyLandSelectionEventTask;
                    //block.OnTokenPlaceInto += UpgradeLandSelectionEventTask;
                    //block.OnTokenPlaceInto += PayForTollEventTask;
                }
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

        private static void BuyLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner == null)
            {
                Console.WriteLine("you can buy the land: {0}  price:{1}", landBlock.land.name, landBlock.land.price);
                Console.WriteLine("buy the land? y/n");
                string instruction;
                while ((instruction = Console.ReadLine()) != "y" && instruction != "n") ;
                if(instruction == "y")
                {
                    landBlock.land.Buy(token.owner);
                    Console.WriteLine(token.owner.username + " buy the land: " + landBlock.land.name);
                    Console.WriteLine("cost money {0}, remain money {1}", landBlock.land.price, token.owner.money);
                }
            }
        }
        //private static void UpgradeLandSelectionEventTask(Block block, Token token)
        //{
        //    LandBlock landBlock = block as LandBlock;
        //    if (landBlock.land.owner == token.owner)
        //    {
        //        if (landBlock.land.isUpgradable && (landBlock.OnUpgradeLandSelection != null))
        //            landBlock.OnUpgradeLandSelection(token.owner, land);
        //        //map.game.response = ResponseType.UpgradeLandSelection;
        //    }
        //}
        //private static void PayForTollEventTask(Block block, Token token)
        //{
        //    LandBlock landBlock = block as LandBlock;
        //    if (landBlock.land.owner != null && landBlock.land.owner != token.owner)
        //    {
        //        if (landBlock.OnPayForToll != null)
        //            landBlock.OnPayForToll(token.owner, land.owner, land.toll);
        //    }
        //}
    }
}

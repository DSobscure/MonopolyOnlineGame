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
                if (block is LandBlock)
                {
                    block.OnTokenPlaceInto += PayForTollEventTask;
                    block.OnTokenPlaceInto += UpgradeLandSelectionEventTask;
                    block.OnTokenPlaceInto += BuyLandSelectionEventTask;
                }
                else if (block is StartBlock)
                {
                    block.OnTokenPass += PassStartBlockEventTask;
                }
                else if (block is CardBlock)
                {
                    block.OnTokenPlaceInto += DrawCardEventTask;
                }
            }
            Console.WriteLine("Game start....");
            string cmd;
            int steps;
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
                Console.Write("{0}({1}), ", land.name, land.level);
            }
            Console.Write("\n");
        }

        private static void TokenInto(Block block, Token token)
        {
            Console.WriteLine(token.owner.username+" go into "+token.position);
            Console.WriteLine("this block is"+block.GetType());
        }

        private static void BuyLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner == null)
            {
                Console.WriteLine("the money you have: {0}", token.owner.money);
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

        private static void UpgradeLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner == token.owner)
            {
                Console.WriteLine("the money you have: {0}", token.owner.money);
                Console.WriteLine("you can upgrade your land: {0}  price:{1}", landBlock.land.name, landBlock.land.tollBase);
                Console.WriteLine("upgrade your land? y/n");
                string instruction;
                while ((instruction = Console.ReadLine()) != "y" && instruction != "n") ;
                if (instruction == "y")
                {
                    landBlock.land.Upgrade(token.owner);
                    Console.WriteLine(token.owner.username + " upgrade his land: " + landBlock.land.name + " to level " + landBlock.land.level);
                    Console.WriteLine("cost money {0}, remain money {1}", landBlock.land.tollBase, token.owner.money);
                }
            }
        }

        private static void PayForTollEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.owner != null && landBlock.land.owner != token.owner)
            {
                landBlock.land.PayToll(token.owner);
                Console.WriteLine("this land is belong to {0}", landBlock.land.owner.username);
                Console.WriteLine("you paid {0} to him", landBlock.land.toll);
                Console.WriteLine("remain money: {0}", token.owner.money);
            }
        }

        private static void PassStartBlockEventTask(Block block, Token token)
        {
            StartBlock startBlock = block as StartBlock;
            token.owner.money += startBlock.salary;
            Console.WriteLine("when passing the startblock, you get {0} dollars. remain money: {1}", startBlock.salary, token.owner.money);
        }

        private static void DrawCardEventTask(Block block, Token token)
        {
            CardBlock cardBlock = block as CardBlock;
            string blockType = "";
            if (cardBlock is DestinyBlock)
                blockType = "Destiny";
            else if (cardBlock is ChanceBlock)
                blockType = "Chance";
            Card card = cardBlock.Draw();
            List<Player> allPlayers = game.players;
            switch (card.type)
            {
                case CardType.GainMoney:
                    token.owner.money += card.value;
                    Console.WriteLine("[{0}] so lucky! you got {1} dollars! remain money: {2}", blockType, card.value, token.owner.money);
                    break;
                case CardType.LoseMoney:
                    token.owner.money -= card.value;
                    Console.WriteLine("[{0}] how terrible! you lose {1} dollars! remain money: {2}", blockType, card.value, token.owner.money);
                    break;
                case CardType.StealMoney:
                    foreach (Player player in allPlayers)
                    {
                        if (player != token.owner)
                            player.money -= card.value;
                    }
                    token.owner.money += card.value * (allPlayers.Count - 1);
                    Console.WriteLine("[{0}] you stole {1} dollars from other players in silence. remain money: {2}", blockType, card.value, token.owner.money);
                    break;
                case CardType.ReleaseMoney:
                    token.owner.money -= card.value * (allPlayers.Count - 1);
                    foreach (Player player in allPlayers)
                    {
                        if (player != token.owner)
                            player.money += card.value;
                    }
                    Console.WriteLine("[{0}] you give {1} dollars to other players just for fun. remain money: {2}", blockType, card.value, token.owner.money);
                    break;
            }
        }
    }
}

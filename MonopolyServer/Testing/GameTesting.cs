using Newtonsoft.Json;
using MonopolyGame;
using System.Collections.Generic;
using System;

namespace MonopolyServer.Testing
{
    public class GameTesting
    {
        public GameTesting()
        {
            Game game = new ServerGame(2000, new List<Player>()
            {
                new Player(1,"test1"),
                new Player(2,"test2")
            }, new List<ServerUser>()
            {

            });
            string gameDataString = JsonConvert.SerializeObject(game.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            System.Console.WriteLine(gameDataString);
            Game resultGame = JsonConvert.DeserializeObject<Game>(gameDataString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            foreach(Block block in resultGame.map.blocks)
            {
                if(block is LandBlock)
                    Console.WriteLine((block as LandBlock).land.name);
            }
            Console.Read();
        }
    }
}

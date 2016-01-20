using MonopolyGame;
using OnlineGameDataStructure;
using System.Collections.Generic;
using MonopolyProtocol;
using Newtonsoft.Json;

namespace MonopolyServer
{
    public class Server
    {
        string version = "0.0.1";
        internal Logger logger;
        Dictionary<string, ServerUser> userDictionary;
        Dictionary<int, ServerGame> gameDictionary;
        internal ServerLobby lobby;

        public Server()
        {
            logger = new Logger();
            userDictionary = new Dictionary<string, ServerUser>();
            gameDictionary = new Dictionary<int, ServerGame>();
            lobby = new ServerLobby();
        }

        public void Broadcast(Peer[] peers, BroadcastType broadcastType, Dictionary<byte, object> parameter)
        {
            EventData eventData = new EventData((byte)broadcastType, parameter);
            foreach (Peer peer in peers)
            {
                peer.SendEvent(eventData);
            }
        }

        public bool UserOnline(ServerUser user)
        {
            if(!userDictionary.ContainsKey(user.userName))
            {
                userDictionary.Add(user.userName, user);
                user.MoveToUserGroup(lobby);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UserOffline(ServerUser user)
        {
            if (userDictionary.ContainsKey(user.userName))
            {
                userDictionary.Remove(user.userName);
                user.MoveToUserGroup(null);
            }
        }

        public bool CreateGame(List<User> users)
        {
            List<Player> players = new List<Player>();
            List<ServerUser> serverUsers = new List<ServerUser>();
            int idCounter = 0;
            foreach (User targetUser in users)
            {
                ServerUser user = targetUser as ServerUser;
                players.Add(user.player = new ServerPlayer(idCounter++, targetUser.userName));
                serverUsers.Add(user);
            }
            ServerGame game = new ServerGame(20000, players, serverUsers);
            game.OnGameOver += CloseGame;
            game.canRollDice = true;
            foreach (Block block in game.map.blocks)
            {
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
            gameDictionary.Add(game.id, game);
            foreach (User targetUser in users)
            {
                (targetUser as ServerUser).playingGame = game;
            }
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                {(byte)GameStartBroadcastParameterItem.GameDataString, JsonConvert.SerializeObject(game.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
            };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in game.users)
            {
                peers.Add(targetUser.Peer);
            }
            Broadcast(peers.ToArray(), BroadcastType.GameStart, parameter);
            return true;
        }

        private void CloseGame(ServerGame game)
        {
            Player winner = game.GameOverReturnWinnner();
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                {(byte)EndGameBroadcastParameterItem.WinerName, winner.username },
                {(byte)EndGameBroadcastParameterItem.WinerMoney, winner.money },
                {(byte)EndGameBroadcastParameterItem.GameDataString, JsonConvert.SerializeObject(game.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
            };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in game.users)
            {
                peers.Add(targetUser.Peer);
                targetUser.playingGame = null;
                if(targetUser == (targetUser.userGroup as Room).host)
                    targetUser.ready = true;
                else
                    targetUser.ready = false;
            }
            Broadcast(peers.ToArray(), BroadcastType.EndGame, parameter);
            gameDictionary.Remove(game.id);
        }

        private void BuyLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.ownerName == null)
            {
                Dictionary<byte, object> parameter = new Dictionary<byte, object>
                {
                    {(byte)BuyLandSelectionBroadcastParameterItem.LandDataString, JsonConvert.SerializeObject(landBlock.land, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                };
                List<Peer> peers = new List<Peer>();
                peers.Add(userDictionary[token.ownerName].Peer);
                Broadcast(peers.ToArray(), BroadcastType.BuyLandSelection, parameter);
            }
        }

        private void UpgradeLandSelectionEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.ownerName == token.ownerName)
            {
                Dictionary<byte, object> parameter = new Dictionary<byte, object>
                {
                    {(byte)UpgradeLandSelectionBroadcastParameterItem.LandDataString, JsonConvert.SerializeObject(landBlock.land, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                };
                List<Peer> peers = new List<Peer>();
                peers.Add(userDictionary[token.ownerName].Peer);
                Broadcast(peers.ToArray(), BroadcastType.UpgradeLandSelection, parameter);
            }
        }

        private void PayForTollEventTask(Block block, Token token)
        {
            LandBlock landBlock = block as LandBlock;
            if (landBlock.land.ownerName != null && landBlock.land.ownerName != token.ownerName)
            {
                Player player = userDictionary[token.ownerName].player;
                Player owner = userDictionary[landBlock.land.ownerName].player;
                landBlock.land.PayToll(player, owner);
                Dictionary<byte, object> parameter1 = new Dictionary<byte, object>
                {
                    {(byte)PayForTollBroadcastParameterItem.PlayerName, player.username },
                    {(byte)PayForTollBroadcastParameterItem.LandName, landBlock.land.name },
                    {(byte)PayForTollBroadcastParameterItem.Toll, landBlock.land.toll },
                    {(byte)PayForTollBroadcastParameterItem.LandOwnerName, owner.username }
                };
                Dictionary<byte, object> parameter2 = new Dictionary<byte, object>
                {
                    {(byte)MonopolyGameStatusChangeBroadcastParameterItem.GameDataString, JsonConvert.SerializeObject((player as ServerPlayer).playingGame.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                };
                List<Peer> peers = new List<Peer>();
                foreach(ServerUser user in ((player as ServerPlayer).playingGame as ServerGame).users)
                {
                    peers.Add(user.Peer);
                }
                Broadcast(peers.ToArray(), BroadcastType.PayForToll, parameter1);
                Broadcast(peers.ToArray(), BroadcastType.MonopolyGameStatusChange, parameter2);
            }
        }

        private void PassStartBlockEventTask(Block block, Token token)
        {
            StartBlock startBlock = block as StartBlock;
            userDictionary[token.ownerName].player.money += startBlock.salary;
            Player player = userDictionary[token.ownerName].player;
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
            {
                {(byte)MonopolyGameStatusChangeBroadcastParameterItem.GameDataString, JsonConvert.SerializeObject((player as ServerPlayer).playingGame.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
            };
            List<Peer> peers1 = new List<Peer>();
            foreach (ServerUser user in ((player as ServerPlayer).playingGame as ServerGame).users)
            {
                peers1.Add(user.Peer);
            }
            List<Peer> peers2 = new List<Peer>();
            peers2.Add(userDictionary[token.ownerName].Peer);
            Broadcast(peers2.ToArray(), BroadcastType.PassStartBlock, new Dictionary<byte, object>());
            Broadcast(peers1.ToArray(), BroadcastType.MonopolyGameStatusChange, parameter);
        }

        private void DrawCardEventTask(Block block, Token token)
        {
            CardBlock cardBlock = block as CardBlock;
            Card card = cardBlock.Draw();
            string blockType = "";
            if (cardBlock is DestinyBlock)
                blockType = "Destiny";
            else if (cardBlock is ChanceBlock)
                blockType = "Chance";
            Player player = userDictionary[token.ownerName].player;
            List<Player> allPlayers = (player as ServerPlayer).playingGame.players;
            switch (card.type)
            {
                case CardType.GainMoney:
                    player.money += card.value;
                    break;
                case CardType.LoseMoney:
                    player.money -= card.value;
                    break;
                case CardType.StealMoney:
                    foreach (Player targetPlayer in allPlayers)
                    {
                        if (targetPlayer != player)
                            targetPlayer.money -= card.value;
                    }
                    player.money += card.value * (allPlayers.Count - 1);
                    break;
                case CardType.ReleaseMoney:
                    player.money -= card.value * (allPlayers.Count - 1);
                    foreach (Player targetPlayer in allPlayers)
                    {
                        if (targetPlayer != player)
                            targetPlayer.money += card.value;
                    }
                    break;
            }
            Dictionary<byte, object> parameter1 = new Dictionary<byte, object>
                {
                    {(byte)DrawCardBroadcastParameterItem.PlayerName, player.username },
                    {(byte)DrawCardBroadcastParameterItem.BlockType, blockType },
                    {(byte)DrawCardBroadcastParameterItem.CardDataString, JsonConvert.SerializeObject(card, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                };
            Dictionary<byte, object> parameter2 = new Dictionary<byte, object>
                {
                    {(byte)MonopolyGameStatusChangeBroadcastParameterItem.GameDataString, JsonConvert.SerializeObject((player as ServerPlayer).playingGame.Serialize(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }) }
                };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser user in ((player as ServerPlayer).playingGame as ServerGame).users)
            {
                peers.Add(user.Peer);
            }
            Broadcast(peers.ToArray(), BroadcastType.DrawCard, parameter1);
            Broadcast(peers.ToArray(), BroadcastType.MonopolyGameStatusChange, parameter2);
        }
    }
}

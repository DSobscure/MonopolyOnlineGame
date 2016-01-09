using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyProtocol;

namespace MonopolyServer
{
    partial class Peer : PeerBase
    {
        private bool SendMessage(string message)
        {
            Dictionary<byte, object> parameter = new Dictionary<byte, object>
                                        {
                                            {(byte)SendMessageBroadcastParameterItem.SenderName, user.UserName },
                                            {(byte)SendMessageBroadcastParameterItem.Message, message}
                                        };
            List<Peer> peers = new List<Peer>();
            foreach (ServerUser targetUser in user.UserGroup.Users.Values)
            {
                peers.Add(targetUser.Peer);
            }
            server.Broadcast(peers.ToArray(), BroadcastType.SendMessage, parameter);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineGameDataStructure;

namespace MonopolyServer
{
    class ServerUser : User
    {
        public Peer Peer { get; set; }

        public ServerUser(string userName, Peer peer) : base(userName)
        {
            Peer = peer;
        }
    }
}

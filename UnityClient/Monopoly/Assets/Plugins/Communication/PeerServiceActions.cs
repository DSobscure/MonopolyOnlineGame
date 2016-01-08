using UnityEngine;
using System.Collections.Generic;
using MonopolyProtocol;

public partial class PeerService
{
    public void Login(string userName)
    {
        var parameters = new Dictionary<byte, object> {
                             { (byte)LoginParameterItem.UserName, userName }
                        };
        peer.Send(new OperationRequest((byte)OperationType.Login, parameters));
    }
}

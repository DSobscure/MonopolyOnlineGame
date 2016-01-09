using UnityEngine;
using System.Collections;
using MonopolyProtocol;
using System;

public partial class PeerService
{
    public void SendMessageEventTask(EventData eventData)
    {
        try
        {
            if (eventData.Parameters.Count == 2)
            {
                string senderName = (string)eventData.Parameters[(byte)SendMessageBroadcastParameterItem.SenderName];
                string message = (string)eventData.Parameters[(byte)SendMessageBroadcastParameterItem.Message];
                if (OnReceiveMessage != null)
                    OnReceiveMessage(senderName, message);
            }
        }
        catch (Exception ex)
        {
            DebugReturn(DebugLevel.Error, ex.Message);
            DebugReturn(DebugLevel.Error, ex.StackTrace);
        }
    }
}

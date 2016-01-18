using UnityEngine;
using System.Collections;

public class MessageController : MonoBehaviour
{
    [SerializeField]
    private MessagePanelUIController messagePanelUIController;

    void Start()
    {
        PeerGlobal.PS.OnSendMessageResponse += OnSendMessageResponseAction;
        PeerGlobal.PS.OnReceiveMessage += OnReceiveMessageAction;
    }

    void OnDestroy()
    {
        PeerGlobal.PS.OnSendMessageResponse -= OnSendMessageResponseAction;
        PeerGlobal.PS.OnReceiveMessage -= OnReceiveMessageAction;
    }

    public void SendMessage()
    {
        string message = messagePanelUIController.FetchInput();
        if (message.Length > 0)
        {
            PeerGlobal.PS.SendMessage(message);
        }
    }

    private void OnSendMessageResponseAction(bool status, string errorMessage)
    {
        if(!status)
        {
            messagePanelUIController.AppendMessage(errorMessage);
        }
    }
    private void OnReceiveMessageAction(string senderName, string message)
    {
        messagePanelUIController.AppendMessage(senderName + ": " + message);
        messagePanelUIController.UpdateMessageBox();
    }
}

using UnityEngine;
using System.Collections;

public class PeerConnect : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 24;
    }

    void Start()
    {
        PeerGlobal.PS.OnConnectResponse += ConnectEventAction;
        if (!PeerGlobal.PS.ServerConnected)
        {
            PeerGlobal.PS.Connect(GameGlobal.ServerIP, GameGlobal. ServerPort);
        }
    }

    private void ConnectEventAction(bool Status)
    {
        if (Status)
        {
            Debug.Log("Connecting . . . . .");
            GameGlobal.ConnectStatus = true;
        }
        else
        {
            Debug.Log("Connect Fail");
            GameGlobal.ConnectStatus = false;
        }
    }

    private void OnDestroy()
    {
        PeerGlobal.PS.OnConnectResponse -= ConnectEventAction;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), "Version: " + GameGlobal.version);
        if (GameGlobal.ConnectStatus == false)
        {
            GUI.Label(new Rect(130, 10, 100, 20), "Connect fail");
        }

        if (PeerGlobal.PS.ServerConnected)
        {
            GUI.Label(new Rect(130, 10, 100, 20), "Connecting . . .");
        }
    }
}

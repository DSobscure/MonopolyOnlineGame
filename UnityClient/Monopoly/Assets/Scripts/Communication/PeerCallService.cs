using UnityEngine;
using System.Collections;

public class PeerCallService : MonoBehaviour
{
    void FixedUpdate()
    {
        PeerGlobal.PS.Service();
    }

    void OnApplicationQuit()
    {
        PeerGlobal.PS.Disconnect();
    }
}

using UnityEngine;
using System.Collections;

public class PeerCallService : MonoBehaviour
{
    int counter = 0;
    void FixedUpdate()
    {
        if (counter % 30 == 0)
            PeerGlobal.PS.Service();
        counter++;
    }

    void OnApplicationQuit()
    {
        PeerGlobal.PS.Disconnect();
    }
}

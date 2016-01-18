using UnityEngine;
using System.Collections;

public class DebugManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PeerGlobal.PS.OnDebugReturn += OnDebugReturnAction;
	}
    void OnDestroy()
    {
        PeerGlobal.PS.OnDebugReturn -= OnDebugReturnAction;
    }

    void OnDebugReturnAction(string debugMessage)
    {
        Debug.Log(debugMessage);
    }
}

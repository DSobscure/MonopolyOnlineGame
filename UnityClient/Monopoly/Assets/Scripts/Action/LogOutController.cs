using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOutController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PeerGlobal.PS.OnLogOut += OnLogOutAction;
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnLogOut -= OnLogOutAction;
    }

    public void LogOut()
    {
        PeerGlobal.PS.LogOut();
    }

    public void OnLogOutAction()
    {
        SceneManager.LoadScene("LoginScene");
    }
}

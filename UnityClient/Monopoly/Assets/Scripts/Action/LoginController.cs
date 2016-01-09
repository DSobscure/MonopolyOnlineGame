using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [SerializeField]
    private LoginUIController loginUIController;

    void Start()
    {
        PeerGlobal.PS.OnLoginResponse += OnLoginResponseAction;
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnLoginResponse -= OnLoginResponseAction;
    }

    public void Login()
    {
        PeerGlobal.PS.Login(loginUIController.userNameInputField.text);
    }

    public void OnLoginResponseAction(bool status)
    {
        if(status)
            SceneManager.LoadScene("LobbyScene");
    }
}

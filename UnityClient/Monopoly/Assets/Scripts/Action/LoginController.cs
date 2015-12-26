using UnityEngine;
using System.Collections;

public class LoginController : MonoBehaviour
{
    public void Login()
    {
        LoginResponseEventAction();
    }

    public void LoginResponseEventAction()
    {
        Application.LoadLevel("LobbyScene");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyStartGameController : MonoBehaviour
{
    public void ReadyStartGame()
    {
        ReadyStartGameResponseEventAction();
    }

    public void ReadyStartGameResponseEventAction()
    {
        SceneManager.LoadScene("MonopolyScene");
    }
}

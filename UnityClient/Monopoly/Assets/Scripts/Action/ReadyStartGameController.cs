using UnityEngine;
using System.Collections;

public class ReadyStartGameController : MonoBehaviour
{
    public void ReadyStartGame()
    {
        ReadyStartGameResponseEventAction();
    }

    public void ReadyStartGameResponseEventAction()
    {
        Application.LoadLevel("MonopolyScene");
    }
}

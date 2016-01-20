using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyStartGameController : MonoBehaviour
{
    public void ReadyStartGame()
    {
        if (GameGlobal.room.host.userName == GameGlobal.userName)
        {
            PeerGlobal.PS.StartGame();
        }
        else
        {
            if (GameGlobal.room.users.ContainsKey(GameGlobal.userName))
            {
                if (GameGlobal.room.users[GameGlobal.userName].ready)
                {
                    PeerGlobal.PS.CancleReady();
                }
                else
                {
                    PeerGlobal.PS.ReadyForGame();
                }
            }
        }
    }

    public void ReadyStartGameResponseEventAction()
    {
        SceneManager.LoadScene("MonopolyScene");
    }
}

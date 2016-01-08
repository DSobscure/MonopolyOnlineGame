using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitRoomController : MonoBehaviour
{
    public void ExitRoom()
    {
        ExitRoomResponseEventAction();
    }

    public void ExitRoomResponseEventAction()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}

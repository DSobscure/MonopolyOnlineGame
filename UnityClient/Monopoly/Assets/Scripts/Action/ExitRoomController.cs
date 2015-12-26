using UnityEngine;
using System.Collections;

public class ExitRoomController : MonoBehaviour
{
    public void ExitRoom()
    {
        ExitRoomResponseEventAction();
    }

    public void ExitRoomResponseEventAction()
    {
        Application.LoadLevel("LobbyScene");
    }
}

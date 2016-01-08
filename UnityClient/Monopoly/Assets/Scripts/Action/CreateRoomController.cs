using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateRoomController : MonoBehaviour
{
    public void CreateRoom()
    {
        CreateRoomResponseEventAction();
    }

    public void CreateRoomResponseEventAction()
    {
        SceneManager.LoadScene("RoomScene");
    }
}

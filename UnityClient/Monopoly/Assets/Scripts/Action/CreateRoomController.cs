using UnityEngine;
using System.Collections;

public class CreateRoomController : MonoBehaviour
{
    public void CreateRoom()
    {
        CreateRoomResponseEventAction();
    }

    public void CreateRoomResponseEventAction()
    {
        Application.LoadLevel("RoomScene");
    }
}

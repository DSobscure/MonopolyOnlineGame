using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using OnlineGameDataStructure;

public class CreateRoomController : MonoBehaviour
{
    [SerializeField]
    private CreateRoomUIController createRoomUIController;

    public void CreateRoom()
    {
        PeerGlobal.PS.CreateRoom(createRoomUIController.RoomName, createRoomUIController.IsEntrcypted, createRoomUIController.Password);
    }
}

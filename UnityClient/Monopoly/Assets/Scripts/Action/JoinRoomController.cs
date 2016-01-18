using UnityEngine;
using UnityEngine.SceneManagement;
using OnlineGameDataStructure;

public class JoinRoomController : MonoBehaviour
{
    [SerializeField]
    private JoinRoomUIController joinRoomUIController;

    private int selectedRoomID;

    void Start ()
    {
        PeerGlobal.PS.OnJoinRoom += OnJoinRoomAction;
    }

    void Destroy()
    {
        PeerGlobal.PS.OnJoinRoom -= OnJoinRoomAction;
    }

    public void SelectRoom(int roomID)
    {
        if(GameGlobal.lobby.rooms.ContainsKey(roomID))
        {
            selectedRoomID = roomID;
            if(GameGlobal.lobby.rooms[roomID].isEncrypted)
            {
                joinRoomUIController.PopPanel();
            }
            else
            {
                JoinRoom();
            }
        }
    }

    public void JoinRoom()
    {
        PeerGlobal.PS.JoinRoom(selectedRoomID);
    }
    public void JoinRoomWithPassword()
    {
        PeerGlobal.PS.JoinRoom(selectedRoomID, joinRoomUIController.FetchPassword());
    }

    private void OnJoinRoomAction(bool status)
    {
        if(status)
        {
            SceneManager.LoadScene("RoomScene");
        }
    }
}

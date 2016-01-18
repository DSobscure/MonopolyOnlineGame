using UnityEngine;
using OnlineGameDataStructure;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelUIController playerPanelUIController;

    void Start ()
    {
        PeerGlobal.PS.OnRoomUpdate += OnRoomUpdateAction;
        playerPanelUIController.UpdatePlayerPanel(GameGlobal.room);
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnRoomUpdate -= OnRoomUpdateAction;
    }

    private void OnRoomUpdateAction(Room room)
    {
        playerPanelUIController.UpdatePlayerPanel(room);
        if(!GameGlobal.lobby.rooms.ContainsKey(room.id))
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }
}

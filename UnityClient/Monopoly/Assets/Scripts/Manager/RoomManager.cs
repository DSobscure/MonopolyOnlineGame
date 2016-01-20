using UnityEngine;
using OnlineGameDataStructure;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelUIController playerPanelUIController;
    [SerializeField]
    private ReadyStartButtonUIController readyStartButtonUIController;

    void Start ()
    {
        PeerGlobal.PS.OnRoomUpdate += OnRoomUpdateAction;
        PeerGlobal.PS.OnGameStart += OnGameStartAction;
        playerPanelUIController.UpdatePlayerPanel(GameGlobal.room);
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnRoomUpdate -= OnRoomUpdateAction;
        PeerGlobal.PS.OnGameStart -= OnGameStartAction;
    }

    private void OnRoomUpdateAction(Room room)
    {
        playerPanelUIController.UpdatePlayerPanel(room);
        readyStartButtonUIController.StartButtonCheck(room);
        if (room.isClosed || !room.users.ContainsKey(GameGlobal.userName))
        {
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            Debug.Log("not colsed");
        }
    }

    private void OnGameStartAction()
    {
        SceneManager.LoadScene("MonopolyScene");
    }
}

using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private RoomPanelUIController roomPanelUIController;

    void Start ()
    {
        PeerGlobal.PS.OnGetLobbyData += OnGetLobbyDataAction;
        PeerGlobal.PS.GetLobbyData();
	}

    void OnDestroy()
    {
        PeerGlobal.PS.OnGetLobbyData -= OnGetLobbyDataAction;
    }

    private void OnGetLobbyDataAction(Lobby lobby)
    {
        roomPanelUIController.UpdateRoomPanel(lobby);
    }
}

using UnityEngine;
using System.Collections;
using OnlineGameDataStructure;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private RoomPanelUIController roomPanelUIController;
    [SerializeField]
    private PlayerListUIController playerListUIController;

    void Start ()
    {
        PeerGlobal.PS.OnGetLobbyData += OnGetLobbyDataAction;
        PeerGlobal.PS.OnLobbyUpdate += OnGetLobbyDataAction;
        PeerGlobal.PS.GetLobbyData();
	}

    void OnDestroy()
    {
        PeerGlobal.PS.OnGetLobbyData -= OnGetLobbyDataAction;
        PeerGlobal.PS.OnLobbyUpdate -= OnGetLobbyDataAction;
    }

    private void OnGetLobbyDataAction(Lobby lobby)
    {
        roomPanelUIController.UpdateRoomPanel(lobby);
        playerListUIController.UpdatePlayerListPanel(lobby);
    }
}

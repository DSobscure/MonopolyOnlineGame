using UnityEngine;
using UnityEngine.UI;
using OnlineGameDataStructure;

public class RoomPanelUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform roomPanel;
    [SerializeField]
    private RectTransform roomButtonPrefab;
    [SerializeField]
    private JoinRoomController joinRoomController;

    public void UpdateRoomPanel(Lobby lobby)
    {
        for (int i = roomPanel.childCount - 1; i >= 0; i--)
        {
            Destroy(roomPanel.GetChild(i).gameObject);
        }
        var roomEnumerator = lobby.rooms.GetEnumerator();
        roomEnumerator.MoveNext();
        for (int i = 0; i < lobby.rooms.Count; i++)
        {
            RectTransform block = Instantiate(roomButtonPrefab);
            block.transform.SetParent(roomPanel);
            block.localScale = Vector3.one;
            block.localPosition = new Vector3(-180 + 120f * (i%4), 55f - 105f*(i/4), 0f);
            block.GetChild(0).GetComponent<Text>().text = roomEnumerator.Current.Value.name;
            block.GetChild(1).GetComponent<Text>().text = roomEnumerator.Current.Value.users.Count.ToString() + "/4";
            int roomID = roomEnumerator.Current.Value.id;
            block.GetComponent<Button>().onClick.AddListener(() => joinRoomController.SelectRoom(roomID));
            roomEnumerator.MoveNext();
        }
    }
}

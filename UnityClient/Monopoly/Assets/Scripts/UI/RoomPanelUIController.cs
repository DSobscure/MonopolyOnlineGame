using UnityEngine;
using UnityEngine.UI;
using OnlineGameDataStructure;

public class RoomPanelUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform roomPanel;
    [SerializeField]
    private RectTransform roomButtonPrefab;

    public void UpdateRoomPanel(Lobby lobby)
    {
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
            //block.GetComponent<Button>().onClick.AddListener(() => SelectItem(blockIndex));
            roomEnumerator.MoveNext();
        }
    }
}

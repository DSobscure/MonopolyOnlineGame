using UnityEngine;
using UnityEngine.UI;
using OnlineGameDataStructure;

public class PlayerPanelUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform playerPanel;
    [SerializeField]
    private RectTransform playerButtonPrefab;

    public void UpdatePlayerPanel(Room room)
    {
        for (int i = playerPanel.childCount - 1; i >= 0; i--)
        {
            Destroy(playerPanel.GetChild(i).gameObject);
        }
        var playerEnumerator = room.users.GetEnumerator();
        playerEnumerator.MoveNext();
        for (int i = 0; i < room.users.Count; i++)
        {
            RectTransform block = Instantiate(playerButtonPrefab);
            block.transform.SetParent(playerPanel);
            block.localScale = Vector3.one;
            block.localPosition = new Vector3(-225f + 150f * i, 0f);
            block.GetChild(0).GetComponent<Text>().text = playerEnumerator.Current.Value.userName;
            //block.GetChild(1).GetComponent<Text>().text = roomEnumerator.Current.Value.users.Count.ToString() + "/4";
            //int roomID = roomEnumerator.Current.Value.id;
            //block.GetComponent<Button>().onClick.AddListener(() => joinRoomController.SelectRoom(roomID));
            playerEnumerator.MoveNext();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using OnlineGameDataStructure;

public class PlayerListUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform playerListPnael;
    [SerializeField]
    private RectTransform playerNamePrefab;

    public void UpdatePlayerListPanel(Lobby lobby)
    {
        for (int i = playerListPnael.childCount - 1; i >= 0; i--)
        {
            Destroy(playerListPnael.GetChild(i).gameObject);
        }
        var playerEnumerator = lobby.users.Values.GetEnumerator();
        playerEnumerator.MoveNext();
        for (int i = 0; i < lobby.users.Count; i++)
        {
            RectTransform block = Instantiate(playerNamePrefab);
            block.transform.SetParent(playerListPnael);
            block.localScale = Vector3.one;
            block.localPosition = new Vector3(0,100 - 30*i);
            block.GetComponent<Text>().text = playerEnumerator.Current.userName;
            playerEnumerator.MoveNext();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class JoinRoomUIController : MonoBehaviour
{
    [SerializeField]
    internal InputField passwordText;
    [SerializeField]
    private RectTransform joinRoomPanel;

    internal void PopPanel()
    {
        joinRoomPanel.gameObject.SetActive(true);
    }

    internal string FetchPassword()
    {
        string password = passwordText.text;
        passwordText.text = "";
        joinRoomPanel.gameObject.SetActive(false);
        return password;
    }
}

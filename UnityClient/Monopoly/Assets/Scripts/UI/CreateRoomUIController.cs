using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUIController : MonoBehaviour
{
    [SerializeField]
    private InputField roomNameInputField;
    [SerializeField]
    private InputField passwordInputField;

    public string RoomName
    {
        get
        {
            return roomNameInputField.text;
        }
    }
    public string Password
    {
        get
        {
            return passwordInputField.text;
        }
    }
    private bool _isEntrcypted = false;
    public bool IsEntrcypted
    {
        get
        {
            return _isEntrcypted;
        }
        set
        {
            passwordInputField.gameObject.SetActive(value);
            _isEntrcypted = value;
        }
    }
    
}

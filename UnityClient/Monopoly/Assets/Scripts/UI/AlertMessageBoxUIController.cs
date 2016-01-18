using UnityEngine;
using UnityEngine.UI;

public class AlertMessageBoxUIController : MonoBehaviour
{
    [SerializeField]
    private Text alertMessage;
    [SerializeField]
    internal GameObject messageBox;

    public void ShowMessage(string message)
    {
        alertMessage.text = message;
    }
}

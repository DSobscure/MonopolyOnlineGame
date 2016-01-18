using UnityEngine;
using System.Collections;

public class AlertHandler : MonoBehaviour
{
    [SerializeField]
    private AlertMessageBoxUIController alertMessageBoxUIController;

    void Start()
    {
        PeerGlobal.PS.OnAlert += OnAlertAction;
    }

    void OnDestroy()
    {
        PeerGlobal.PS.OnAlert -= OnAlertAction;
    }

    private void OnAlertAction(string message)
    {
        alertMessageBoxUIController.messageBox.SetActive(true);
        alertMessageBoxUIController.ShowMessage(message);
    }
}

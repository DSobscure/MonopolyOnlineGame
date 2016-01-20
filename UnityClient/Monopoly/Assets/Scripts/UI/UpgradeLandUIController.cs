using UnityEngine;
using MonopolyGame;
using UnityEngine.UI;
using System.Text;

public class UpgradeLandUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform upgradeLandSelectionPanel;
    [SerializeField]
    private Text messageText;

    internal void PanelSwitch(bool active)
    {
        upgradeLandSelectionPanel.gameObject.SetActive(active);
    }
    internal void UpdatePanel(Land land)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Format("you can upgrade your land: {0}  price:{1}", land.name, land.tollBase));
        messageText.text = stringBuilder.ToString();
    }
}

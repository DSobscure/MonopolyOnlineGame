using UnityEngine;
using MonopolyGame;
using UnityEngine.UI;
using System.Text;

public class BuyLandUIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform buyLandSelectionPanel;
    [SerializeField]
    private Text messageText;

    internal void PanelSwitch(bool active)
    {
        buyLandSelectionPanel.gameObject.SetActive(active);
    }
    internal void UpdatePanel(Land land)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Format("you can buy the land: {0}  price:{1}", land.name, land.price));
        messageText.text = stringBuilder.ToString();
    }
}

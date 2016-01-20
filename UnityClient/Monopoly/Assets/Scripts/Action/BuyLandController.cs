using UnityEngine;
using MonopolyGame;

public class BuyLandController : MonoBehaviour
{
    [SerializeField]
    private BuyLandUIController buyLandUIController;

    void Start()
    {
        PeerGlobal.PS.OnBuyLandSelection += OnBuyLandSelectionAction;
        PeerGlobal.PS.OnBuyLand += OnBuyLandAction;
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnBuyLandSelection -= OnBuyLandSelectionAction;
        PeerGlobal.PS.OnBuyLand -= OnBuyLandAction;
    }
    public void BuyLand()
    {
        PeerGlobal.PS.BuyLand();
        buyLandUIController.PanelSwitch(false);
    }
    private void OnBuyLandSelectionAction(Land land)
    {
        buyLandUIController.PanelSwitch(true);
        buyLandUIController.UpdatePanel(land);
    }
    private void OnBuyLandAction(string playerName, string landName)
    {
        PeerGlobal.PS.Alert(string.Format("{0} buy the land: {1}", playerName, landName));
    }
}

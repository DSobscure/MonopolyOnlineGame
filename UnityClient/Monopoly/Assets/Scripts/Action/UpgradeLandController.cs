using UnityEngine;
using MonopolyGame;

public class UpgradeLandController : MonoBehaviour
{
    [SerializeField]
    private UpgradeLandUIController upgradeLandUIController;

    void Start ()
    {
        PeerGlobal.PS.OnUpgradeLandSelection += OnUpgradeSelectionAction;
        PeerGlobal.PS.OnUpgrade += OnUpgradeAction;
    }
	void OnDestroy()
    {
        PeerGlobal.PS.OnUpgradeLandSelection -= OnUpgradeSelectionAction;
        PeerGlobal.PS.OnUpgrade -= OnUpgradeAction;
    }
    public void UpgradeLand()
    {
        PeerGlobal.PS.UpgradeLand();
        upgradeLandUIController.PanelSwitch(false);
    }
    private void OnUpgradeSelectionAction(Land land)
    {
        upgradeLandUIController.PanelSwitch(true);
        upgradeLandUIController.UpdatePanel(land);
    }
    private void OnUpgradeAction(string playerName, string landName, int nowLevel)
    {
        PeerGlobal.PS.Alert(string.Format("{0} upgrade his land: {1} to level {2}", playerName, landName, nowLevel));
    }
}

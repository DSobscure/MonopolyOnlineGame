using UnityEngine;
using UnityEngine.UI;

public class EndTurnUIController : MonoBehaviour
{
    [SerializeField]
    private Button endTurnButton;

    public void EndTurn()
    {
        endTurnButton.enabled = false;
    }
    public void MyTurn()
    {
        endTurnButton.enabled = true;
    }
}

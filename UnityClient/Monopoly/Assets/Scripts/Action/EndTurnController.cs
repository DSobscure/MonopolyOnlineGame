using UnityEngine;
using System.Collections;

public class EndTurnController : MonoBehaviour
{
    [SerializeField]
    private EndTurnUIController endTurnUIController;
    [SerializeField]
    private DiceUIController diceUIController;

    public void EndTurn()
    {
        endTurnUIController.EndTurn();
        diceUIController.SetDiceNumber(0);
        PeerGlobal.PS.EndTurn();
    }

    public void MyTurn()
    {
        endTurnUIController.MyTurn();
    }
}

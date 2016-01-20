using UnityEngine;
using System.Collections;

public class RollDiceController : MonoBehaviour
{
    [SerializeField]
    private DiceUIController diceUIController;

    void Start()
    {
        PeerGlobal.PS.OnRollDice += diceUIController.SetDiceNumber;
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnRollDice -= diceUIController.SetDiceNumber;
    }

    public void RollDice()
    {
        PeerGlobal.PS.RollDice();
        diceUIController.RollDice();
    }

    public void OnMyTurn()
    {
        diceUIController.WaitForRoll();
    }
}

using UnityEngine;
using UnityEngine.UI;
using System;

public class DiceUIController : MonoBehaviour
{
    [SerializeField]
    private Button diceButton;
    [SerializeField]
    private Text diceNumber;
    private bool randomDiceNumber = false;

    void Start()
    {
        if(GameGlobal.playingGame.players[GameGlobal.playingGame.turnCounter % GameGlobal.playingGame.players.Count].username == GameGlobal.userName)
        {
            diceButton.enabled = true;
        }
        else
        {
            diceButton.enabled = false;
        }
    }

    public void RollDice()
    {
        diceButton.enabled = false;
        randomDiceNumber = true;
    }

    void Update()
    {
        if(randomDiceNumber)
        {
            diceNumber.text = new System.Random().Next(1,6).ToString();
        }
    }

    public void SetDiceNumber(int number)
    {
        randomDiceNumber = false;
        diceButton.enabled = false;
        diceNumber.text = number.ToString();
    }

    public void WaitForRoll()
    {
        diceButton.enabled = true;
        diceNumber.text = "請擲骰子";
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Text;
using MonopolyGame;

public class GameTotalUIController : MonoBehaviour
{
    [SerializeField]
    private Text totalText;
    [SerializeField]
    private RectTransform totalPanel;

    public void UpdateTotalResult(string winnerName, int winnerMoney)
    {
        totalPanel.gameObject.SetActive(true);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("winner is {0}\n with {1} dollars!\n", winnerName, winnerMoney);
        foreach(Player player in GameGlobal.playingGame.players)
        {
            stringBuilder.AppendFormat("Player: {0} fianl money: {1}\n", player.username, player.money);
        }
        totalText.text = stringBuilder.ToString();
    }
}

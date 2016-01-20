using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MonopolyGame;
using System.Text;

public class PlayerDataUIController : MonoBehaviour
{
    [SerializeField]
    private Text plaerDataPanel;

    void Start()
    {
        UpdatePlayerDataPanel(GameGlobal.playingGame.players);
    }

    internal void UpdatePlayerDataPanel(List<Player> players)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (Player player in players)
        {
            stringBuilder.AppendLine("Name: " + player.username);
            stringBuilder.AppendLine("Money: " + player.money);
            stringBuilder.Append("Land: ");
            foreach (Land land in player.landList)
            {
                stringBuilder.Append(string.Format("{0}({1}), ", land.name, land.level));
            }
            stringBuilder.Append("\n\n");
        }
        plaerDataPanel.text = stringBuilder.ToString();
    }
}

using UnityEngine;
using System.Collections.Generic;
using MonopolyGame;
using System.Text;
using UnityEngine.SceneManagement;

public class MonopolyManager : MonoBehaviour
{
    [SerializeField]
    private MapUIController mapUIController;
    [SerializeField]
    private RollDiceController rollDiceController;
    [SerializeField]
    private EndTurnController endTurnController;
    [SerializeField]
    private TokenUIController tokenUIController;
    [SerializeField]
    private PlayerDataUIController playerDataUIController;
    [SerializeField]
    private GameTotalUIController gameTotalUIController;

    internal List<RectTransform> blocks;

    void Start()
    {
        blocks = new List<RectTransform>();
        PeerGlobal.PS.OnMonopolyGameUpdate += OnMonopolyGameUpdateAction;
        PeerGlobal.PS.OnPayForToll += OnPayForTollAction;
        PeerGlobal.PS.OnPassStartBlock += OnPassStartBlockAction;
        PeerGlobal.PS.OnDrawCard += OnDrawCardAction;
        PeerGlobal.PS.OnEndGame += OnEndGameAction;
        mapUIController.UpdateMap(GameGlobal.playingGame.map);
    }
    void OnDestroy()
    {
        PeerGlobal.PS.OnMonopolyGameUpdate -= OnMonopolyGameUpdateAction;
        PeerGlobal.PS.OnPayForToll -= OnPayForTollAction;
        PeerGlobal.PS.OnPassStartBlock -= OnPassStartBlockAction;
        PeerGlobal.PS.OnDrawCard -= OnDrawCardAction;
        PeerGlobal.PS.OnEndGame -= OnEndGameAction;
    }

    private void OnMonopolyGameUpdateAction(Game game)
    {
        if (game.players[game.turnCounter % game.players.Count].username == GameGlobal.userName && game.canRollDice)
        {
            rollDiceController.OnMyTurn();
            endTurnController.MyTurn();
        }
        for (int i = 0; i < game.players.Count; i++)
        {
            Player player = game.players[i];
            TokenUIController.TokenInformation information = tokenUIController.playerTokensInformation[player.username];
            information.position.Enqueue(player.token.position);
        }
        playerDataUIController.UpdatePlayerDataPanel(game.players);
    }
    private void OnPayForTollAction(string player, string landName, int toll, string ownerName)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat(" this land {0} is belong to {1} \n", landName, ownerName);
        stringBuilder.AppendFormat(" {0} paid {1} to {2} \n", player, toll, ownerName);
        PeerGlobal.PS.Alert(stringBuilder.ToString());
    }
    private void OnPassStartBlockAction()
    {
        PeerGlobal.PS.Alert(string.Format("when passing the startblock, you get some money."));
    }
    private void OnDrawCardAction(string playerName, string blockType, Card card)
    {
        StringBuilder stringBuilder = new StringBuilder();

        switch (card.type)
        {
            case CardType.GainMoney:
                stringBuilder.AppendFormat("[{0}] so lucky! {1} got {2} dollars!", blockType, playerName, card.value);
                break;
            case CardType.LoseMoney:
                stringBuilder.AppendFormat("[{0}] how terrible! {1} lose {2} dollars!", blockType, playerName, card.value);
                break;
            case CardType.StealMoney:
                stringBuilder.AppendFormat("[{0}] {1} stole {2} dollars from other players in silence.", blockType, playerName, card.value);
                break;
            case CardType.ReleaseMoney:
                stringBuilder.AppendFormat("[{0}] {1} give {2} dollars to other players just for fun.", blockType, playerName, card.value);
                break;
        }

        PeerGlobal.PS.Alert(stringBuilder.ToString());
    }
    private void OnEndGameAction(string winnerName, int winnerMoney)
    {
        gameTotalUIController.UpdateTotalResult(winnerName, winnerMoney);
    }
    public void AfterReadTotal()
    {
        SceneManager.LoadScene("RoomScene");
    }
}

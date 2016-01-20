using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MonopolyGame;

public class TokenUIController : MonoBehaviour
{
    public struct TokenInformation
    {
        public RectTransform tokenObject;
        public float prograss;
        public Queue<int> position;
    }

    [SerializeField]
    private RectTransform tokenPrefab;
    internal Dictionary<string, TokenInformation> playerTokensInformation;
    [SerializeField]
    private MonopolyManager monopolyManager;
    [SerializeField]
    private RectTransform mapPanelUpper;

    void Start ()
    {
        playerTokensInformation = new Dictionary<string, TokenInformation>();
        for (int i = 0; i < GameGlobal.playingGame.players.Count; i++)
        {
            Player player = GameGlobal.playingGame.players[i];
            RectTransform token = Instantiate(tokenPrefab);
            token.SetParent(mapPanelUpper);
            token.localScale = Vector3.one;
            token.localPosition = Vector3.zero;
            var information = new TokenInformation()
            {
                tokenObject = token,
                prograss = 0,
                position = new Queue<int>()
            };
            information.position.Enqueue(player.token.position);
            playerTokensInformation.Add(player.username, information);
        }
	}

    void Update()
    {
        var informationEnumertaor = playerTokensInformation.Values.GetEnumerator();
        informationEnumertaor.MoveNext();
        for (int i = 0; i < playerTokensInformation.Count; i++)
        {
            TokenInformation information = informationEnumertaor.Current;
            if (information.position.Count > 0)
            {
                information.prograss += Time.deltaTime;
                information.tokenObject.localPosition = Vector3.Lerp(information.tokenObject.localPosition, monopolyManager.blocks[information.position.Peek()].localPosition+new Vector3(5*i-10,0), information.prograss);
                if (information.prograss > 1 || (information.tokenObject.localPosition- monopolyManager.blocks[information.position.Peek()].localPosition + new Vector3(5 * i - 10, 0)).magnitude<40f)
                {
                    information.tokenObject.localPosition = monopolyManager.blocks[information.position.Peek()].localPosition + new Vector3(5 * i - 10, 0);
                    information.prograss = 0;
                    information.position.Dequeue();
                    Debug.Log("finish move token!");
                }
            }
            informationEnumertaor.MoveNext();
        }
    }
}

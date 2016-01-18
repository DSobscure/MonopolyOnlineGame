using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class MessagePanelUIController : MonoBehaviour
{
    private List<string> messageContent = new List<string>();
    private StringBuilder showingContent = new StringBuilder();
    [SerializeField]
    private InputField inputText;
    [SerializeField]
    private RectTransform messageBox;
    [SerializeField]
    private Text showingText;
    [SerializeField]
    private Scrollbar scrollBar;

    public string FetchInput()
    {
        string fetchResult = inputText.text;
        inputText.text = "";
        return fetchResult;
    }

    public void AppendMessage(string message)
    {
        messageContent.Add(message);
        showingContent.AppendLine(message);
    }

    public void UpdateMessageBox()
    {
        showingText.text = showingContent.ToString();
        showingText.rectTransform.sizeDelta = new Vector2(showingText.rectTransform.rect.width, showingText.preferredHeight);
        scrollBar.value = 0;
    }
}

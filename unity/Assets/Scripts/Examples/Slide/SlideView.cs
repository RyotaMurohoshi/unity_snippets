using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SlideView : MonoBehaviour
{
    [SerializeField]
    Text titleText;
    public Text TitleText { get { return titleText; } }

    [SerializeField]
    Text sentenceText;
    public Text SentenceText { get { return sentenceText; } }

    [SerializeField]
    Image background;
    public Image Image { get { return background; } }


    public Content Content
    {
        set
        {
            titleText.text = value.Title;
            titleText.color = value.TextColor;

            sentenceText.text = value.Sentence;
            sentenceText.color = value.TextColor;

            background.color = value.BackgroundColor;
        }
    }
}

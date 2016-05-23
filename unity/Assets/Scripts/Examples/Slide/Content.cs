using UnityEngine;

[SerializeField]
public class Content
{
    public Content(
        string title,
        string sentence,
        Color textColor,
        Color backgroundColor
        )
    {
        this.title = title;
        this.sentence = sentence;
        this.textColor = textColor;
        this.backgroundColor = backgroundColor;
    }

    [SerializeField]
    string title;
    public string Title { get { return title; } }

    [SerializeField]
    string sentence;
    public string Sentence { get { return sentence; } }

    [SerializeField]
    Color textColor = Color.white;
    public Color TextCollor { get { return textColor; } }

    [SerializeField]
    Color backgroundColor = Color.black;
    public Color BackgroundColor { get { return backgroundColor; } }
}

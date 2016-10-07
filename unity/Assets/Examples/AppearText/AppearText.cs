using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class AppearText : MonoBehaviour
{
    [SerializeField]
    float duration = 0.5F;

    [SerializeField]
    float moveY = 100;

    [SerializeField]
    bool playOnStart;

    void Start()
    {
        if (playOnStart)
        {
            Show();
        }
    }

    public Tweener Show()
    {
        var originalPosition = transform.position;
        transform.position += moveY * Vector3.down;
        transform.DOMove(originalPosition, duration);

        var text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0F);
        return text.DOFade(1.0F, duration);
    }
}

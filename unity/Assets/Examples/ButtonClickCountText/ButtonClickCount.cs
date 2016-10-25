using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ButtonClickCount : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    Text text;

    void Awake()
    {
        button.OnClickAsObservable()
            .Select(_ => 1)
            .Scan(0, (element, acc) => element + acc)
            .SubscribeToText(text)
            .AddTo(gameObject);
    }
}
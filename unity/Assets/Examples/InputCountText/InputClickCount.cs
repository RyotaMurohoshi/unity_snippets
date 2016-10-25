using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class InputClickCount : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Awake()
    {
        IObservable<int> clickCountStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => 1)
            .Scan((acc, current) => acc + current);

        clickCountStream
            .SubscribeToText(text)
            .AddTo(gameObject);
    }
}
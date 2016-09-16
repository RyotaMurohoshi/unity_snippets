using UnityEngine;
using UniRx;
using System;

public class HpIndicatorExample : MonoBehaviour
{
    [SerializeField]
    FloatReactiveProperty floatValue;

    [SerializeField]
    HpIndicator hpIndicator;

    void Start()
    {
        hpIndicator.Initialize();
        floatValue
            .Select<float, float>(Mathf.Clamp01)
            .Throttle(TimeSpan.FromSeconds(0.5F))
            .Subscribe(value => hpIndicator.AnimateValue(value))
            .AddTo(gameObject);
    }
}

using UnityEngine;
using UniRx;

public class HpBarExample : MonoBehaviour
{
    [SerializeField]
    FloatReactiveProperty floatValue;

    [SerializeField]
    HpBar hpBar;

    [SerializeField]
    HpIndicator hpIndicator;

    void Start()
    {
        hpIndicator.Initialize();
        floatValue.Select<float, float>(Mathf.Clamp01).Subscribe(hpIndicator.SetValue).AddTo(gameObject);
        floatValue.Select<float, float>(Mathf.Clamp01).Subscribe(hpBar.SetRate).AddTo(gameObject);
    }
}

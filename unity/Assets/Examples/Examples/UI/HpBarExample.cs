using UnityEngine;
using UniRx;

public class HpBarExample : MonoBehaviour
{
    [SerializeField]
    FloatReactiveProperty floatValue;

    [SerializeField]
    HpBar hpBar;
    
    void Start()
    {
        floatValue.Select<float, float>(Mathf.Clamp01).Subscribe(hpBar.SetRate).AddTo(gameObject);
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpIndicator : MonoBehaviour
{
    [SerializeField]
    Slider frontSlider;
    [SerializeField]
    Slider backgroundSlider;

    float maxValue;

    public void Initialize(float maxValue = 1.0F)
    {
        this.maxValue = maxValue;

        frontSlider.maxValue = maxValue;

        if (backgroundSlider)
        {
            backgroundSlider.maxValue = maxValue;
        }
    }

    public void SetValue(float value)
    {
        var clampedValue = Mathf.Clamp(value: value, min: 0, max: maxValue);

        frontSlider.value = clampedValue;

        if (backgroundSlider)
        {
            backgroundSlider.value = clampedValue;
        }
    }

    public Tweener AnimateValue(float value)
    {
        var clampedValue = Mathf.Clamp(value: value, min: 0, max: maxValue);

        var frontTween = frontSlider.DOValue(endValue: clampedValue, duration: 0.3F);

        if (backgroundSlider)
        {
            return backgroundSlider.DOValue(endValue: clampedValue, duration: 0.35F).SetDelay(0.35F);
        }
        else
        {
            return frontTween;
        }
    }
}

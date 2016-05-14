using UnityEngine;
using UnityEngine.UI;

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
}

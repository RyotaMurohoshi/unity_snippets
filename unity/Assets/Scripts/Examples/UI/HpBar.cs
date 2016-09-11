using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    Transform scalingTarget;
    [SerializeField]
    SpriteRenderer coloringTarget;
    float originlLocalScaleX;

    void Awake()
    {
        this.originlLocalScaleX = scalingTarget.localScale.x;
        SetRate(1.0F);
    }

    public void SetRate(float rate)
    {
        float nextScaleX = rate * originlLocalScaleX;
        float nextScaleY = scalingTarget.localScale.y;
        float nextScaleZ = scalingTarget.localScale.z;
        scalingTarget.localScale = new Vector3(nextScaleX, nextScaleY, nextScaleZ);

        if (rate < 0.3F)
        {
            coloringTarget.color = Color.red;
        }
        else if (rate < 0.5F)
        {
            coloringTarget.color = Color.yellow;
        }
        else
        {
            coloringTarget.color = Color.green;
        }
    }
}

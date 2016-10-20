using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HoldReaction : MonoBehaviour
{
    [SerializeField]
    float scaleFactor = 1.0F;

    public void Show()
    {
        transform.localScale = Vector3.zero;
    }

    public void ChangeScale(float scale)
    {
        transform.localScale = Mathf.Max(0.5F, scaleFactor * scale) * Vector3.one;
    }
}

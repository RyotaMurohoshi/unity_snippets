using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class EaseTypeExample : MonoBehaviour
{
    [SerializeField]
    Ease ease = Ease.Linear;
    [SerializeField]
    float duration = 1.0F;
    [SerializeField]
    Vector3 moveVector = Vector3.up;
    [SerializeField]
    Text text;

    Vector3 originalPosition;

    void Awake()
    {
        this.originalPosition = transform.position;
        this.text.text = ease.ToString();
    }

    public void MoveAndReset()
    {
        StartCoroutine(MoveAndResetEnumerator());
    }

    public IEnumerator MoveAndResetEnumerator()
    {
        yield return transform
            .DOMove(originalPosition + moveVector, duration)
            .SetEase(ease)
            .WaitForCompletion();
        yield return new WaitForSeconds(0.3F);
        transform.position = originalPosition;
    }
}

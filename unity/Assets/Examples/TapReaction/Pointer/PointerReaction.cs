using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PointerReaction : MonoBehaviour
{
    float scale = 1.0F;
    public Coroutine Show()
    {
        return StartCoroutine(ShowCorutonine());
    }

    IEnumerator ShowCorutonine()
    {
        transform.localScale = Vector3.zero;
        yield return transform.DOScale(1.0F * Vector3.one, 0.2F).WaitForCompletion();
    }

    public void ChangeScale(float scale)
    {
        this.scale = Mathf.Max(0.5F, scale);
        transform.localScale = this.scale * Vector3.one;
    }

    public Coroutine Hide()
    {
        return StartCoroutine(HideCorutonine());
    }

    IEnumerator HideCorutonine()
    {
        yield return transform.DOScale(Vector3.zero, scale * 0.01F).WaitForCompletion();
        Destroy(gameObject);
    }
}

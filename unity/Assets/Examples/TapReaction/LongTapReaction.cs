using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LongTapReaction : MonoBehaviour
{
    public Coroutine Show()
    {
        return StartCoroutine(ShowCorutonine());
    }

    IEnumerator ShowCorutonine()
    {
        transform.localScale = Vector3.zero;
        yield return transform.DOScale(1.0F * Vector3.one, 0.2F).WaitForCompletion();
    }

    public Coroutine Hide()
    {
        return StartCoroutine(HideCorutonine());
    }

    IEnumerator HideCorutonine()
    {
        transform.localScale = Vector3.one;
        yield return transform.DOScale(1.0F * Vector3.zero, 0.2F).WaitForCompletion();
        Destroy(gameObject);
    }

}

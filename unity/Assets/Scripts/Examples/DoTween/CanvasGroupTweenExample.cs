using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class CanvasGroupTweenExample : MonoBehaviour
{
    [SerializeField]
    CanvasGroup target;

    IEnumerator Start()
    {
        while (true)
        {
            yield return target.DOFade(0.0F, 2.0F).WaitForCompletion();
            yield return new WaitForSeconds(1.0F);
            yield return target.DOFade(1.0F, 2.0F).WaitForCompletion();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System;
using UniRx;

public class TextAnimationCancelRx : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    Text text;

    Tweener tweener;

    IEnumerator Start()
    {
        var textString = text.text;
        text.text = "";

        while (true)
        {
            tweener = text
                .DOText(textString, 5)
                .SetEase(Ease.Linear);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                if (tweener != null)
                {
                    tweener.Kill();
                    tweener = null;
                    text.text = textString;
                }
            });

            yield return tweener.WaitForCompletion();

            yield return Observable.Merge(
                Observable.Timer(TimeSpan.FromSeconds(1.0)).Select(_ => Unit.Default),
                button.OnClickAsObservable()
                )
                .First()
                .StartAsCoroutine();

            text.text = string.Empty;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

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

        button.onClick.AddListener(() =>
        {
            if (tweener != null)
            {
                tweener.Kill();
            }
        });

        while (true)
        {
            text.text = "";
            this.tweener = text
                .DOText(endValue: textString, duration: 10.0F)
                .SetEase(Ease.Linear);
            this.tweener.OnKill(() => text.text = textString);
            yield return this.tweener.WaitForCompletion();
            yield return new WaitForSeconds(1.0F);
        }
    }
}

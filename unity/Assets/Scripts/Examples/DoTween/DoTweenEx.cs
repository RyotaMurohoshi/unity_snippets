using UnityEngine.UI;
using System;
using DG.Tweening;

public static class DOTweenEx
{
    public static Tweener DOTextInt(this Text text,int initialValue, int finalValue, Func<int, string> setter, float duration)
    {
        return DOTween.To(
             () => initialValue,
             it => text.text = setter(it),
             finalValue,
             duration
         );
    }

    public static Tweener DOTextFloat(this Text text, float initialValue, float finalValue, Func<float, string> setter, float duration)
    {
        return DOTween.To(
             () => initialValue,
             it => text.text = setter(it),
             finalValue,
             duration
         );
    }

    public static Tweener DOTextLong(this Text text, long initialValue, long finalValue, Func<long, string> setter, float duration)
    {
        return DOTween.To(
             () => initialValue,
             it => text.text = setter(it),
             finalValue,
             duration
         );
    }
}

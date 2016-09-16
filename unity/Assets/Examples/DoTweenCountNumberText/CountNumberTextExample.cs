using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class CountNumberTextExample : MonoBehaviour
{
    [SerializeField]
    Text text;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0F);

        yield return text
            .DOTextInt(0, 100, it => string.Format("{0}!", 100 - it), 3.0F)
            .SetEase(Ease.Linear)
            .WaitForCompletion();

        text.text = "Finish!";
    }
}

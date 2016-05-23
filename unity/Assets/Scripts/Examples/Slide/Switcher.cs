using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Switcher : MonoBehaviour
{
    [SerializeField]
    RectTransform first;

    [SerializeField]
    RectTransform second;

    IEnumerator Start()
    {
        var defaultPosition = first.transform.position;
        var leftPosition = defaultPosition + Vector3.left * Screen.width;
        var rightPosition = defaultPosition + Vector3.right * Screen.width;
        var duration = 0.5F;

        var current = first;
        var next = second;
        next.transform.position = rightPosition;

        while (true)
        {
            yield return new WaitForSeconds(1.0F);

            current.transform.DOMove(leftPosition, duration);
            yield return next.transform.DOMove(defaultPosition, duration).WaitForCompletion();

            var temp = current;
            current = next;
            next = temp;

            next.transform.position = rightPosition;
        }
    }
}

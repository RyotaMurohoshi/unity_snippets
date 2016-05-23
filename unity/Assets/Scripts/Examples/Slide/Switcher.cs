using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Switcher : MonoBehaviour
{
    [SerializeField]
    RectTransform first;
    public RectTransform First { get { return first; } }

    [SerializeField]
    RectTransform second;
    public RectTransform Second { get { return second; } }

    float animationDuration = 1.0F;
    public RectTransform Current { get; private set; }
    public RectTransform Next { get; private set; }
    Vector3 defaultPosition;

    public void Initialize(float animationDuration)
    {
        this.defaultPosition = first.transform.position;

        this.Current = first;

        this.Next = second;
        this.Next.transform.position = defaultPosition + Vector3.right * Screen.width;

        this.animationDuration = animationDuration;
    }

    public IEnumerator Switch()
    {
        var leftPosition = defaultPosition + Vector3.left * Screen.width;
        var rightPosition = defaultPosition + Vector3.right * Screen.width;

        Next.transform.position = rightPosition;

        Current.transform.DOMove(leftPosition, animationDuration);
        yield return Next.transform.DOMove(defaultPosition, animationDuration).WaitForCompletion();

        var temp = Current;
        this.Current = Next;
        this.Next = temp;

        Next.transform.position = rightPosition;
    }
}

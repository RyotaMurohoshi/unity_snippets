using UnityEngine;
using DG.Tweening;

public class ExampleMoveWindow : MonoBehaviour
{
    const float Duration = 0.5F;

    Vector3 defaultPosition;
    void Start()
    {
        defaultPosition = transform.position;
        transform.position = defaultPosition + Vector3.up * Screen.height;
    }

    public Tweener Show()
    {
        return transform.DOMove(defaultPosition, Duration);
    }

    public Tweener Hide()
    {
        return transform.DOMove(defaultPosition + Screen.height * Vector3.down, Duration);
    }

}

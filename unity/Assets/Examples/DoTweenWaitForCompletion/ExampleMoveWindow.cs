using UnityEngine;
using DG.Tweening;

public class ExampleMoveWindow : MonoBehaviour
{
    const float Duration = 0.5F;

    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Screen.height);
    }

    public Tweener Show()
    {
        return transform.DOMove(Vector3.zero, Duration);
    }

    public Tweener Hide()
    {
        return transform.DOMove(Screen.height * Vector2.down, Duration);
    }

}

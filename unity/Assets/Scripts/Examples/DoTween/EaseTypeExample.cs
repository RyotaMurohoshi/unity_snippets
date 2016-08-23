using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EaseTypeExample : MonoBehaviour
{
    [SerializeField]
    float duration = 1.0F;
    [SerializeField]
    Ease easeType;
    [SerializeField]
    Button button;
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform start;
    [SerializeField]
    Transform goal;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        target.transform.position = start.position;
        target.DOMove(goal.position, duration).SetEase(easeType);
    }
}

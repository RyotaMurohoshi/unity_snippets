using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PunchExample : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    SpriteRenderer target;

    void Awake()
    {
        button.onClick.AddListener(() => {
            target.transform.DOPunchPosition(
                punch : Vector3.up,
                duration : 0.3F,
                vibrato: 10,
                elasticity : 1,
                snapping: false);
        });
    }
}

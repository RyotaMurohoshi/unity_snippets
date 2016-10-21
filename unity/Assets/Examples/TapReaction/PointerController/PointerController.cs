using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    PointerReaction currentReaction;
    Vector2ReactiveProperty vector2ReactiveProperty = new Vector2ReactiveProperty(Vector2.zero);

    [SerializeField]
    PointerReaction reactionPrefab;

    [SerializeField]
    GameObject target;

    void Awake()
    {
        this.UpdateAsObservable()
            .CombineLatest(vector2ReactiveProperty, (_, vec) => vec)
            .Subscribe(it => {
                target.transform.position += 0.025F * (Vector3)it;
            });
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        currentReaction = CreateReaction(eventData.position);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (currentReaction != null)
        {
            vector2ReactiveProperty.Value = Vector2.zero;
            currentReaction.Hide();
            currentReaction = null;
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (currentReaction != null)
        {
            var fromPosition = currentReaction.transform.position;
            var toPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            var distance = Vector3.Distance(fromPosition, toPosition);
            var scale = 2 * distance;
            currentReaction.ChangeScale(scale);

            var diff = toPosition - fromPosition;
            vector2ReactiveProperty.Value = Mathf.Min(5.0F, diff.magnitude) * diff.normalized;
        }
    }

    PointerReaction CreateReaction(Vector3 position)
    {
        var tapReaction = Instantiate(reactionPrefab);
        tapReaction.transform.position = Camera.main.ScreenToWorldPoint(position);
        tapReaction.Show();
        return tapReaction;
    }
}
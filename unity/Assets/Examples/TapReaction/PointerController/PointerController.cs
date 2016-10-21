using UnityEngine;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    PointerReaction currentReaction;

    [SerializeField]
    PointerReaction reactionPrefab;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        currentReaction = CreateReaction(eventData.position);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (currentReaction != null)
        {
            currentReaction.Hide();
            currentReaction = null;
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (currentReaction != null)
        {
            var position = Camera.main.ScreenToWorldPoint(eventData.position);
            var distance = Vector3.Distance(currentReaction.transform.position, position);
            var scale = 2 * distance;
            currentReaction.ChangeScale(scale);
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
using UnityEngine;
using System.Linq;
using UniRx;
using UniRx.Triggers;

public class HoldReactionManager : MonoBehaviour
{
    [SerializeField]
    HoldReaction holdReactionPrefab;

    void Start()
    {
        var mouseUpStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0));

        var mouseHoldsStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButton(0))
            .Select(_ => Input.mousePosition)
            .Select(it => Camera.main.ScreenToWorldPoint(it));

        var reactionStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => Input.mousePosition)
            .Select(positioin => CreateReaction(positioin));

        reactionStream
            .CombineLatest(mouseHoldsStream, (reaction, mouseHoldPosition) => new { reaction, mouseHoldPosition })
            .Subscribe(it =>
            {
                it.reaction.ChangeScale(Vector3.Distance(it.reaction.transform.position, it.mouseHoldPosition));
            })
            .AddTo(gameObject);
    }

    HoldReaction CreateReaction(Vector3 position)
    {
        var tapReaction = Instantiate(holdReactionPrefab);
        tapReaction.transform.position = Camera.main.ScreenToWorldPoint(position);
        tapReaction.Show();
        return tapReaction;
    }
}

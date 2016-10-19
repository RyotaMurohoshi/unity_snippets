using UnityEngine;
using System.Linq;
using System;
using UniRx;
using UniRx.Triggers;

public class LongTapReactionManager : MonoBehaviour
{
    [SerializeField]
    LongTapReaction tapReactionPrefab;

    void Start()
    {
        var mouseUpStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0));

        var reactionStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => Input.mousePosition)
            .Select(positioin => CreateReaction(positioin));

        reactionStream
            .Zip(mouseUpStream, (reaction, mouseUp) => new { reaction, mouseUp })
            .Subscribe(it => it.reaction.Hide())
            .AddTo(gameObject);
    }

    LongTapReaction CreateReaction(Vector3 position)
    {
        var tapReaction = Instantiate(tapReactionPrefab);
        tapReaction.transform.position = Camera.main.ScreenToWorldPoint(position);
        tapReaction.Show();
        return tapReaction;
    }
}

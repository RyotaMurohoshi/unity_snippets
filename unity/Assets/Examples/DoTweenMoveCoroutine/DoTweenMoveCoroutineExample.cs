using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class DoTweenMoveCoroutineExample : MonoBehaviour
{
    [SerializeField]
    List<Transform> targets;

    [SerializeField]
    Transform mover;

    [SerializeField]
    float velocity = 1.0F;

    IEnumerator Start()
    {
        while (true)
        {
            foreach (var target in targets)
            {
                var distance = Vector3.Distance(target.position, mover.position);
                var duration = distance / velocity;
                yield return mover.transform.DOMove(target.position, duration).WaitForCompletion();
            }
        }
    }
}

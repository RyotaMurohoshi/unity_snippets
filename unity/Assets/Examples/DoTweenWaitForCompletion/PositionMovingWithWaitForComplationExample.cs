using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class PositionMovingWithWaitForComplationExample : MonoBehaviour
{
    [SerializeField]
    Transform mover;

    [SerializeField]
    List<Transform> positions;

    IEnumerator Start()
    {
        foreach (var position in PositionRepeating(positions))
        {
            yield return mover
                .DOMove(position, 0.5F)
                .WaitForCompletion();
        }
    }

    IEnumerable<Vector3> PositionRepeating(IEnumerable<Transform> positions)
    {
        while (true)
        {
            foreach (var it in positions)
            {
                yield return it.position;
            }
        }
    }
}

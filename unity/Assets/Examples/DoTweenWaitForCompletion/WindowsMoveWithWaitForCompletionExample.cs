using UnityEngine;
using System.Collections;
using DG.Tweening;

public class WindowsMoveWithWaitForCompletionExample : MonoBehaviour
{
    [SerializeField]
    ExampleMoveWindow window1;

    [SerializeField]
    ExampleMoveWindow window2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0F);

        yield return window1.Show().WaitForCompletion();

        yield return new WaitForSeconds(1.0F);

        yield return window1.Hide().WaitForCompletion();

        yield return new WaitForSeconds(0.3F);

        yield return window2.Show().WaitForCompletion();

        yield return new WaitForSeconds(1.0F);

        yield return window2.Hide().WaitForCompletion();
    }
}

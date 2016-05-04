using UnityEngine;
using System.Collections;
using UniRx;

public class CoroutineWhenAll : MonoBehaviour
{
    IEnumerator Start()
    {
        var list = new[] {
            new {
                delaySeconds = 1.0F,
                message = "Hello"
            },
            new {
                delaySeconds = 3.0F,
                message = "Bye"
            },
            new {
                delaySeconds = 5.0F,
                message = "Good night"
            }
        };

        yield return Observable
            .WhenAll(
                list
                    .ToObservable()
                    .SelectMany(it => Observable.FromCoroutine(() => ShowAfterDelay(it.message, it.delaySeconds)))
            ).StartAsCoroutine();

        Debug.Log("Finished");
    }


    IEnumerator ShowAfterDelay(string message, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Debug.Log(message);
    }
}

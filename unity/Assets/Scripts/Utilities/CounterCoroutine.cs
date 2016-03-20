using UnityEngine;
using System.Collections;

public class CounterCoroutine : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return SubCoroutine(1.0F);
        yield return new WaitForSeconds(1.0F);
    }

    IEnumerator SubCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

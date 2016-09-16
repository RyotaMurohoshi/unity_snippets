using UnityEngine;
using System.Collections;
using System;

public class CustomYieldInstructionExample : MonoBehaviour
{
    [SerializeField]
    bool waitUntil = false;
    [SerializeField]
    bool waitWhile = true;

    void Start()
    {
        StartCoroutine(WaitUntilCoroutine());
        StartCoroutine(WaitWhileCoroutine());
        StartCoroutine(RepeatMyWaitForSecondsCoroutine(count: 3, seconds:1.0F));
    }

    IEnumerator WaitUntilCoroutine()
    {
        Debug.Log("WaitUntilCoroutine Begin");
        yield return new WaitUntil(() => waitUntil);
        Debug.Log("WaitUntilCoroutine Finish");
    }

    IEnumerator WaitWhileCoroutine()
    {
        Debug.Log("WaitWhileCoroutine Begin");
        yield return new WaitWhile(() => waitWhile);
        Debug.Log("WaitWhileCoroutine Finish");
    }

    IEnumerator MyWaitForSecondsCoroutine(float seconds)
    {
        Debug.Log("MyWaitForSecondsCoroutine Begin : " + System.DateTime.Now);
        yield return new MyWaitForSeconds(seconds);
        Debug.Log("MyWaitForSecondsCoroutine Finish : " + System.DateTime.Now);
    }

    IEnumerator RepeatMyWaitForSecondsCoroutine(int count, float seconds)
    {
        for(int i = 0; i < count; i++)
        {
            yield return MyWaitForSecondsCoroutine(seconds);
        }
    }
}

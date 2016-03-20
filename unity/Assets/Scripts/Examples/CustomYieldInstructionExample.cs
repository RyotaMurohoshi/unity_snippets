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
<<<<<<< 4c8db37d471b502ea05afde7ed54f4f7bcc2d007
        StartCoroutine(MyWaitForSecondsCoroutine());
=======
        StartCoroutine(RepeatMyWaitForSecondsCoroutine(count: 3, seconds:1.0F));
>>>>>>> created MyWaitForSeconds
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

<<<<<<< 4c8db37d471b502ea05afde7ed54f4f7bcc2d007
    IEnumerator MyWaitForSecondsCoroutine()
    {
        Debug.Log("MyWaitForSecondsCoroutine Begin : " + System.DateTime.Now);
        yield return new MyWaitForSeconds(5.0F);
        Debug.Log("MyWaitForSecondsCoroutine Finish : " + System.DateTime.Now);
    }
=======
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
>>>>>>> created MyWaitForSeconds
}

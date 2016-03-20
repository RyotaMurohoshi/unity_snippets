﻿using UnityEngine;
using System.Collections;

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
        StartCoroutine(MyWaitForSecondsCoroutine());
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

    IEnumerator MyWaitForSecondsCoroutine()
    {
        Debug.Log("MyWaitForSecondsCoroutine Begin : " + System.DateTime.Now);
        yield return new MyWaitForSeconds(5.0F);
        Debug.Log("MyWaitForSecondsCoroutine Finish : " + System.DateTime.Now);
    }
}

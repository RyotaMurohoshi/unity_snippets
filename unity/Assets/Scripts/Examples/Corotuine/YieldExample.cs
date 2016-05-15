using UnityEngine;
using System.Collections;

public class YieldExample : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return ShowCoroutine("Hello", "World", "!");
    }

    IEnumerator ShowCoroutine(params string[] args)
    {
        foreach(var arg in args)
        {
            Debug.Log(arg);
            yield return new WaitForSeconds(1.0F);
        }
    }
}

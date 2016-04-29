using UnityEngine;
using System.Collections;

public class MyWaitForSeconds : IEnumerator
{
    private readonly float finishAt;

    public MyWaitForSeconds(float waitForSeconds)
    {
        finishAt = Time.time + waitForSeconds;
    }

    public object Current
    {
        get
        {
            return null;
        }
    }

    public bool MoveNext()
    {
        return Time.time <= this.finishAt;
    }

    public void Reset()
    {
    }
}

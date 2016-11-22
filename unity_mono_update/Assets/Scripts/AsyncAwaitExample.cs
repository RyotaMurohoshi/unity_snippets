using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class AsyncAwaitExample : MonoBehaviour
{
    async void Awake()
    {
        var num = await ParentTask();

        Debug.Log(num);
    }

    public async Task<int> ParentTask()
    {
        int ret1 = await DelayReturn(delay: TimeSpan.FromSeconds(1), value : 2);
        Debug.Log(ret1);
        int ret2 = await DelayReturn(delay: TimeSpan.FromSeconds(2), value : 1);
        Debug.Log(ret2);
        await Task.Delay(TimeSpan.FromSeconds(1));
        return ret1 + ret2;
    }

    public async Task<int> DelayReturn(TimeSpan delay, int value)
    {
        await Task.Delay(delay);
        return value;
    }
}

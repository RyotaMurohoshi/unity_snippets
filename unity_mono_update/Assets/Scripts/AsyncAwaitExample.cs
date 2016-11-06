using UnityEngine;
using System;
using System.Threading.Tasks;

public class AsyncAwaitExample : MonoBehaviour
{
    async void Awake()
    {
        var num = await ComplexAsyncTask();
        Debug.Log(num);
    }

    public async Task<int> ComplexAsyncTask()
    {
        Func<int> asyncJob = () =>
        {
            //時間のかかる処理
            int i = 0;
            for (i = 0; i < 1000000000; i++)
            {
            }
            return i;
        };

        int ret1 = await Task.Run(asyncJob);
        int ret2 = await Task.Run(asyncJob);
        return ret1 + ret2;
    }
}

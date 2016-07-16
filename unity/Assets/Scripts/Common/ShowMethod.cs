using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class ShowMethod : MonoBehaviour
{
    void Start()
    {
        var assembly = Assembly.Load("UnityEngine.dll");
        Debug.Log(assembly.FullName);

        var types = assembly
            .GetTypes()
            .Where(it => it.IsPublic)
            .ToArray();

        foreach (var type in types)
        {
            ShowType(type);
        }
    }

    void ShowType(Type type)
    {
        Debug.Log(type);
    }
}

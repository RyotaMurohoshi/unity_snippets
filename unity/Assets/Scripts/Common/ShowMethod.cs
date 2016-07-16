using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class ShowMethod : MonoBehaviour
{
    void Start()
    {
        var assembly = Assembly.Load("UnityEngine.dll");

        ShowType(typeof(Vector3));
    }

    void ShowAllMethods(Assembly assembly)
    {
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
        var flags = BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.DeclaredOnly
            | BindingFlags.Public;

        foreach (var method in type.GetMethods(flags))
        {
            Debug.Log(method.Name);
        }
    }
}
using UnityEngine;
using System.Reflection;

public class ShowMethod : MonoBehaviour
{
    void Start()
    {
        var assembly = Assembly.Load("UnityEngine.dll");
        Debug.Log(assembly.FullName);
    }
}

using UnityEngine;
using System.IO;
using System.Linq;

public class CompareMethod : MonoBehaviour
{
    [SerializeField]
    string typeName;
    void Start()
    {
        var assemblyDebugInfo472 = JsonUtility.FromJson<AssemblyDebugInfo>(File.ReadAllText("result_4_7_2.json"));
        var debug472 = assemblyDebugInfo472.Types.First(it => it.Name == typeName);

        var assemblyDebugInfo535 = JsonUtility.FromJson<AssemblyDebugInfo>(File.ReadAllText("result_5_3_5.json"));
        var debug535 = assemblyDebugInfo535.Types.First(it => it.Name == typeName);

        foreach (var name in debug535.Methods.Select(it => it.MethodName).Except(debug472.Methods.Select(it => it.MethodName)))
        {
            Debug.Log(name);
        }
    }

    void ShowDiffTypes()
    {
        var json472 = File.ReadAllText("result_4_7_2.json");
        var assemblyDebugInfo472 = JsonUtility.FromJson<AssemblyDebugInfo>(json472);
        var typeNames472 = assemblyDebugInfo472.Types.Select(it => it.Name).ToArray();

        var json535 = File.ReadAllText("result_5_3_5.json");
        var assemblyDebugInfo535 = JsonUtility.FromJson<AssemblyDebugInfo>(json535);
        var typeNames535 = assemblyDebugInfo535.Types.Select(it => it.Name).ToArray();

        foreach (var name in typeNames535.Except(typeNames472))
        {
            Debug.Log(name);
        }
    }
}

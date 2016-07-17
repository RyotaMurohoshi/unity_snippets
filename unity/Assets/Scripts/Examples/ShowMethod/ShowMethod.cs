using UnityEngine;
using System.IO;

public class ShowMethod : MonoBehaviour
{
    void Start()
    {
        var info = new AssemblyDebugInfo("UnityEngine.dll");
        File.WriteAllText("result.json", JsonUtility.ToJson(info, true));
    }
}

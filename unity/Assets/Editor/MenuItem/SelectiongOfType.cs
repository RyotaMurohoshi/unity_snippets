using UnityEngine;
using UnityEditor;
using System.Linq;

public class SelectiongOfType
{
    [MenuItem("Assets/Example/Selecting User Of Type/")]
    public static void Show()
    {
        foreach (var texture in Selection.objects.OfType<Texture2D>())
        {
            Debug.Log(texture.name);
        }
    }
}

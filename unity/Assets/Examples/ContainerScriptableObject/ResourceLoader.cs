using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class ResourceLoader
{
    public static List<Magic> LoadMagicList()
    {
        return LoadList<MagicScriptableObject, Magic>("ScriptableObjects/Magic");
    }

    public static List<TData> LoadList<TScriptableObject, TData>(string path) where TScriptableObject : Object, IContainer<TData>
    {
        return Resources.LoadAll<TScriptableObject>(path).Select(it => it.Data).ToList();
    }
}

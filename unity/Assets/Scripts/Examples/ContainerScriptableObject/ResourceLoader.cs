using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class ResourceLoader
{
    public static List<Magic> LoadMagicList()
    {
        return Resources.LoadAll<MagicScriptableObject>("ScriptableObjects/Magic").Select(it => it.Data).ToList();
    }
}

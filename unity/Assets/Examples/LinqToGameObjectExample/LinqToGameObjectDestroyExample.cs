using UnityEngine;
using UnityEngine.UI;
using Unity.Linq;
using System.Linq;

public class LinqToGameObjectDestroyExample : MonoBehaviour
{
    void Start()
    {
        GameObjectExtensions.DescendantsEnumerable decendants = gameObject.Descendants();
        decendants.Destroy();
    }
}

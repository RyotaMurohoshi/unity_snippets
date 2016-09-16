using UnityEngine;
using Unity.Linq;
using System.Linq;

public class LinqToGameObjectExample : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    void Start()
    {
        target.Children().Select(it => it.name);
    }
}

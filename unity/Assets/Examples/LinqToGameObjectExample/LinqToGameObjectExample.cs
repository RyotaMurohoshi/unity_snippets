using UnityEngine;
using UnityEngine.UI;
using Unity.Linq;
using System.Linq;

public class LinqToGameObjectExample : MonoBehaviour
{
    void Start()
    {
        // We can use OfComponent instead of Select and Where
        //        foreach (var image in gameObject.Descendants()
        //            .Select(it => it.GetComponent<Image>())
        //            .Where(it => it != null))
        foreach (var image in gameObject.Descendants().OfComponent<Image>())
        {
            image.color = Color.white;
        }
    }
}

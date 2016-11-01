using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZipExample : MonoBehaviour
{
    [SerializeField]
    List<Text> textList;
    [SerializeField]
    List<string> nameList;

    void Awake()
    {
        textList.ForEach(it => it.text = string.Empty);

        foreach (var it in textList.Zip(nameList, (text, name) => new { text, name }))
        {
            it.text.text = it.name;
        }
    }
}

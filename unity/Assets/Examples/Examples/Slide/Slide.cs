using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Switcher))]
public class Slide : MonoBehaviour
{
    [SerializeField]
    List<Content> contentList;

    IEnumerator Start()
    {
        var counter = 0;
        var switcher = GetComponent<Switcher>();

        switcher.Initialize(animationDuration: 0.3F);
        switcher.First.GetComponent<SlideView>().Content = contentList.First();

        while (true)
        {
            counter++;

            var nextIndex = counter % contentList.Count;
            var nectContent = contentList[nextIndex];
            switcher.Next.GetComponent<SlideView>().Content = nectContent;

            yield return new WaitForSeconds(1.0F);
            yield return switcher.Switch();


        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ScreenSizeBinder : MonoBehaviour {
    public int SDScreenWidht = 1024;

    void loadSpriteAtlasWithTag(string tag, System.Action<SpriteAtlas> callback)
    {
        string resourceToLoad = tag;
        if (Screen.width <= SDScreenWidht)
            resourceToLoad = tag + "_SD";
        StartCoroutine(LoadSpriteAtlasAsync(resourceToLoad, callback));
    }

    IEnumerator LoadSpriteAtlasAsync(string resourceToLoad, System.Action<SpriteAtlas> callback)
    {
        var res = Resources.LoadAsync(resourceToLoad);
        yield return res;
        
        var sa = res.asset as SpriteAtlas;
        if (sa != null)
            callback(sa);
    }

    void OnEnable()
    {
        SpriteAtlas.onLoadSpriteAtlasWithTag += loadSpriteAtlasWithTag;
    }

    void OnDisable()
    {
        SpriteAtlas.onLoadSpriteAtlasWithTag -= loadSpriteAtlasWithTag;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ManualBinder : MonoBehaviour {
    public SpriteAtlas[] spriteAtlases;

    void OnGUI()
    {
        foreach (var sa in spriteAtlases)
        {
            if (GUILayout.Button(sa.isVariant ? "  SD  " : "  HD  "))
                SpriteAtlas.BindSpriteAtlas(sa);
        }
    }
}

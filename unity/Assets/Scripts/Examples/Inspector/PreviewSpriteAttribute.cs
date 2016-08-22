using UnityEngine;

public class PreviewSpriteAttribute : PropertyAttribute
{
    public Rect lastPosition = new Rect(0, 0, 0, 0);

    public PreviewSpriteAttribute() { }
}
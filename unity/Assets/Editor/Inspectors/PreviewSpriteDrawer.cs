using UnityEngine;
using UnityEditor;
using System.IO;

[CustomPropertyDrawer(typeof(PreviewSpriteAttribute))]
public class PreviewTextureDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 16;
        property.objectReferenceValue = (Sprite)EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Sprite), false);

        if (property.objectReferenceValue != null)
            DrawTexture(position, (Sprite)property.objectReferenceValue);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + previewSptiteAttribute.lastPosition.height;
    }

    PreviewSpriteAttribute previewSptiteAttribute
    {
        get { return (PreviewSpriteAttribute)attribute; }
    }

    private GUIStyle style;

    void DrawTexture(Rect position, Sprite sprite)
    {
        float width = Mathf.Clamp(sprite.texture.width, position.width * 0.7F, position.width * 0.7F);
        previewSptiteAttribute.lastPosition = new Rect(
            position.width * 0.15F,
            position.y + 16,
            width,
            sprite.texture.height * (width / sprite.texture.width));

        if (style == null)
        {
            style = new GUIStyle();
            style.imagePosition = ImagePosition.ImageOnly;
        }
        style.normal.background = sprite.texture;
        GUI.Label(previewSptiteAttribute.lastPosition, "", style);
    }
}

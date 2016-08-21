using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PreviewSpriteAttribute))]
public class PreviewSpriteDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        property.objectReferenceValue = EditorGUI.ObjectField(
            rect,
            label,
            property.objectReferenceValue,
            typeof(Sprite),
            false);
    }
}
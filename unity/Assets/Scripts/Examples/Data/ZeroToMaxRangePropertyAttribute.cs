using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ZeroToMaxRangePropertyAttribute : PropertyAttribute
{
    public float max;

    public ZeroToMaxRangePropertyAttribute(float max)
    {
        this.max = max;
    }
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(ZeroToMaxRangePropertyAttribute))]
public class ZeroToMaxRangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var target = (ZeroToMaxRangePropertyAttribute) attribute;

        if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.Slider(position, property, 0, target.max, label);
        }
    }
}

#endif
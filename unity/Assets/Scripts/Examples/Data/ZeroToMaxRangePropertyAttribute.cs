using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FloatZeroToMaxRangePropertyAttribute : PropertyAttribute
{
    public float max;

    public FloatZeroToMaxRangePropertyAttribute(float max)
    {
        this.max = max;
    }
}

public class IntZeroToMaxRangePropertyAttribute : PropertyAttribute
{
    public int max;

    public IntZeroToMaxRangePropertyAttribute(int max)
    {
        this.max = max;
    }
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(FloatZeroToMaxRangePropertyAttribute))]
public class FloatZeroToMaxRangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var target = (FloatZeroToMaxRangePropertyAttribute) attribute;

        if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.Slider(position, property, 0, target.max, label);
        }
    }
}


[CustomPropertyDrawer(typeof(IntZeroToMaxRangePropertyAttribute))]
public class IntZeroToMaxRangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var target = (IntZeroToMaxRangePropertyAttribute)attribute;

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.IntSlider(position, property, 0, target.max, label);
        }
    }
}

#endif
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(PlayerData))]
public class PlayerDataInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawProperties();
        serializedObject.ApplyModifiedProperties();
    }

    void DrawProperties()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("playerName"), new GUIContent("PlayerName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("level"), new GUIContent("Level"));
    }
}
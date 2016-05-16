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

    //各要素の描画
    void DrawProperties()
    {
        PlayerData obj = target as PlayerData;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("playerName"), new GUIContent("PlayerName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("level"), new GUIContent("Level"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sprite"), new GUIContent("Sprite"));
        GUILayout.Label(obj.Sprite.texture);
    }
}
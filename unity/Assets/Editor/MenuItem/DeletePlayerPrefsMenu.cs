using UnityEngine;
using UnityEditor;

public class DeletePlayerPrefsMenu
{
    [MenuItem("Tools/Delete All PlayerPrefs %#D")]
    public static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

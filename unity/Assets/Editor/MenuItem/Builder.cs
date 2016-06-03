using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

public static class Build
{
    [MenuItem("Tools/Build Production APK")]
    public static void BuildApk()
    {
        var signConfigPath = Application.dataPath + "/../../SignConfig.json";
        var signConfig = JsonUtility.FromJson<SignConfig>(File.ReadAllText(signConfigPath));

        PlayerSettings.Android.keystoreName = signConfig.keystoreName;
        PlayerSettings.Android.keystorePass = signConfig.keystorePass;
        PlayerSettings.Android.keyaliasName = signConfig.keyaliasName;
        PlayerSettings.Android.keyaliasPass = signConfig.keyaliasPass;

        var outputPath = string.Format("{0}_{1}.apk", PlayerSettings.bundleIdentifier, PlayerSettings.bundleVersion);
        var scenePaths = EditorBuildSettings
            .scenes
            .Where(it => it.enabled)
            .Select(it => it.path)
            .ToArray();

        string errorMessage = BuildPipeline.BuildPlayer(
            levels: scenePaths,
            locationPathName: outputPath,
            target: BuildTarget.Android,
            options: BuildOptions.None);

        if (string.IsNullOrEmpty(errorMessage))
        {
            Debug.Log("[Success!]");
        }
        else {
            Debug.LogError("[Error!] " + errorMessage);
        }

        PlayerSettings.Android.keystoreName = "";
        PlayerSettings.Android.keystorePass = "";
        PlayerSettings.Android.keyaliasName = "";
        PlayerSettings.Android.keyaliasPass = "";
    }
}

class SignConfig
{
    public string keystoreName;
    public string keystorePass;
    public string keyaliasName;
    public string keyaliasPass;
}

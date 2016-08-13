using UnityEngine;

public static class SocialMediaUtility
{
    public static void OpenGooglePlay(string packageName)
    {
        Application.OpenURL(string.Format("market://details?id={0}", packageName));
    }
}

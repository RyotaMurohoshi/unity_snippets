using UnityEngine;

public static class SocialMediaUtility
{
    public static void OpenGooglePlay(string packageName)
    {
        Application.OpenURL(string.Format("market://details?id={0}", packageName));
    }

    public static void OpenAppStore(string bundleIdentifier)
    {
        Application.OpenURL(string.Format("itms-apps://itunes.apple.com/app/id{0}?mt=8", bundleIdentifier));
    }
}

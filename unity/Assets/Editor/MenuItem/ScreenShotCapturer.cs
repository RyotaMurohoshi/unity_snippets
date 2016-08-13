using UnityEditor;
using UnityEngine;

public class ScreenShotCapturer
{
    [MenuItem("Tools/Capture GameView Screenshot")]
    static void CaptureScreenshot()
    {
        var filename = string.Format("GameView_{0}.png", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
        var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView");
        EditorWindow.GetWindow(type).Repaint();

        Application.CaptureScreenshot(filename);
        Debug.Log("Capture GameView : " + filename);
    }
}

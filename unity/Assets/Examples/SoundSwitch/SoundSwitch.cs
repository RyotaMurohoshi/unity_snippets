using UnityEngine;

public class SoundSwitch : MonoBehaviour
{
    public void EnableSound()
    {
        ChangeAudioListenerEnable(soundEnable: true);
    }

    public void DisableSound()
    {
        ChangeAudioListenerEnable(soundEnable: false);
    }

    void ChangeAudioListenerEnable(bool soundEnable)
    {
        foreach (var audioListener in FindObjectsOfType<AudioListener>())
        {
            audioListener.enabled = soundEnable;
        }
    }
}

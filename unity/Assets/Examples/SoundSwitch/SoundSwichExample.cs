using UnityEngine;
using UnityEngine.UI;

public class SoundSwichExample : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    Text text;

    SoundSwitch soundSwitch;
    bool enableSound;

    void Awake()
    {
        soundSwitch = GetComponent<SoundSwitch>();
        enableSound = false;
        SetSoundEnable(enableSound);

        button.onClick.AddListener(() =>
        {
            enableSound = !enableSound;
            SetSoundEnable(enableSound);
        });
    }

    void SetSoundEnable(bool enable)
    {
        text.text = enable ? "Sound Enable" : "Sound Disable";
        if(enable)
        {
            soundSwitch.EnableSound();
        }
        else
        {
            soundSwitch.DisableSound();
        }
    }
}

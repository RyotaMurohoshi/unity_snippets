using UnityEngine;
using UnityEngine.UI;

public class UnityEventDataExampleEventEmitter : MonoBehaviour
{
    [SerializeField]
    UnityEventData unityEventData;

    [SerializeField]
    Button button;

    void Awake()
    {
        button.onClick.AddListener(() => unityEventData.Invoke(new Data(Color.black, "Black")));
    }
}

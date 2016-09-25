using UnityEngine;
using UnityEngine.UI;

public class EaseTypeExampleCaller : MonoBehaviour
{
    [SerializeField]
    Button button;

    void Awake()
    {
        button.onClick.AddListener(() =>
        {
            foreach (var easeExample in FindObjectsOfType<EaseTypeExample>())
            {
                easeExample.MoveAndReset();
            }
        });
    }
}

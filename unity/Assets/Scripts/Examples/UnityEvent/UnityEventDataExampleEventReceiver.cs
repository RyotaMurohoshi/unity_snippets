using UnityEngine;

public class UnityEventDataExampleEventReceiver : MonoBehaviour
{
    public void Receive(ColorData data)
    {
        Debug.Log(string.Format("{0} {1}", data.Name, data.Color));
    }
}

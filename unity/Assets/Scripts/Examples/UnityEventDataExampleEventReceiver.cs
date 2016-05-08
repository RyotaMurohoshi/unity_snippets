using UnityEngine;

public class UnityEventDataExampleEventReceiver : MonoBehaviour
{
    public void Receive(Data data)
    {
        Debug.Log(string.Format("{0} {1}", data.Name, data.Color));
    }
}

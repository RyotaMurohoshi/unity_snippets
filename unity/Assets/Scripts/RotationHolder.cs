using UnityEngine;

public class RotationHolder : MonoBehaviour
{
    Quaternion rotation;

    void Awake()
    {
        rotation = transform.rotation;            
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}

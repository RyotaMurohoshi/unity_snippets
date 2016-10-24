using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TrackingCamera : MonoBehaviour
{
    [SerializeField]
    Transform target;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);
    }
}

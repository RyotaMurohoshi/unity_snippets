using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SimpleKeyInputMove : MonoBehaviour
{
    void Update()
    {
        Vector3 vector = Vector3.zero;

        if (Input.GetKey(KeyCode.DownArrow)) { vector += Vector3.down; }
        if (Input.GetKey(KeyCode.UpArrow)) { vector += Vector3.up; }
        if (Input.GetKey(KeyCode.RightArrow)) { vector += Vector3.right; }
        if (Input.GetKey(KeyCode.LeftArrow)) { vector += Vector3.left; }

        transform.position += 0.1F * vector;
    }
}

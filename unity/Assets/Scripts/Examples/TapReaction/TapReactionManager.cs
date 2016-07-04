using UnityEngine;
using System.Linq;

public class TapReactionManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTap(Input.mousePosition);
        }

        if (Input.touchCount > 0)
        {
            foreach(var touch in Input.touches.Where(it => it.phase == TouchPhase.Began))
            {
                OnTap(touch.position);
            }
        }
    }

    void OnTap(Vector3 position)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Camera.main.ScreenToWorldPoint(position);
    }
}

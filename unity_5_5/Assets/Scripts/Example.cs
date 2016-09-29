using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Example : MonoBehaviour
{
	public Rigidbody Rigidbody => GetComponent<Rigidbody>();
	public Collider Collider => GetComponent<Collider>();
	public string GameObjectName() => gameObject.name;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Example : MonoBehaviour
{
	public Rigidbody Rigidbody => GetComponent<Rigidbody>();
	public string LoadName() => gameObject.name;
}

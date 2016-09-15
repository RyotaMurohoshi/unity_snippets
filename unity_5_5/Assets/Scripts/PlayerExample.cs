using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExample : MonoBehaviour
{
	void Start ()
	{
		Debug.Log(new Player(name:"Ryota", level:28));
	}
}

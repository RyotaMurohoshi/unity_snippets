using UnityEngine;
using System;

[Serializable]
public class Data
{
	[SerializeField] Color color;

	[SerializeField] String name;

	public Color Color { get { return color; } }

	public String Name { get { return name; } }
}

using UnityEngine;
using System;

[Serializable]
public class Data
{
    public Data(Color color, string name)
    {
        this.color = color;
        this.name = name;
    }

    [SerializeField]
    Color color;

    [SerializeField]
    string name;

    Vector3 destination;

    public Color Color { get { return color; } }

    public string Name { get { return name; } }
}

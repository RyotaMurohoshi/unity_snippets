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
    String name;

    public Color Color { get { return color; } }

    public String Name { get { return name; } }
}

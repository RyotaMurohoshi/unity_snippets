using UnityEngine;
using System;

[Serializable]
public class ColorData
{
    public ColorData(Color color, string name)
    {
        this.color = color;
        this.name = name;
    }

    [SerializeField]
    Color color;

    [SerializeField]
    string name;

    public Color Color { get { return color; } }

    public string Name { get { return name; } }
}

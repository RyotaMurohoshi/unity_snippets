using UnityEngine;
using System;

[Serializable]
public class Item
{
    [SerializeField]
    string name;
    public string Name { get { return name; } }

    [SerializeField]
    int price;
    public int Price { get { return price; } }
}

[CreateAssetMenu]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField]
    Item data;
    public Item Data { get { return data; } }
}
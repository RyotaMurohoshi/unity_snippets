using UnityEngine;

public class AbstractWeapon : ScriptableObject
{
    [SerializeField]
    int point;
    public int Point { get { return point; } }

    [SerializeField]
    string weaponName;
    public string WeaponName { get { return weaponName; } }

    [ZeroToMaxRangeProperty(100)]
    [SerializeField]
    float price;
    public float Price { get { return price; } }
}

using UnityEngine;

public class AbstractWeapon : ScriptableObject
{
    [SerializeField]
    int point;
    public int Point { get { return point; } }

    [SerializeField]
    string weaponName;
    public string WeaponName { get { return weaponName; } }

    [IntZeroToMaxRangeProperty(100)]
    [SerializeField]
    int price;
    public int Price { get { return price; } }
}

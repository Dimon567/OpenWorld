using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData", order = 51)]
public class WeaponData : ItemData
{
    [SerializeField] private int _damage;
    [SerializeField] private int _range;
    [SerializeField] private int _durability;

    public int Damage
    {
        get { return _damage; }
    }

    public int Range { 
        get { return _range; } 
    }

    public int Durability { 
        get { return _durability; } 
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "NewClothesData", menuName = "Scriptable Objects/ClothesData")]
public class ClothesData : ItemData
{
    [SerializeField] private int _armor;
    [SerializeField] private int _damageReduction;
}

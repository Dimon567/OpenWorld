using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "Scriptable Objects/Clothes")]
public class ClothesData : ScriptableObject
{
    [SerializeField] private int _armor;
    [SerializeField] private int _damageReduction;
}

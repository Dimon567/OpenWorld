using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<CraftComponent> _craftComponents;
    

    public string Name {
        get { return _name; }
    }

    public string Desctiprion {
        get { return _description; }
    }

    public Sprite Icon
    {
        get { return _icon; }
    }

    public GameObject Prefab
    {
        get { return _prefab; }
    }

    public List<CraftComponent> Components{
        get{ 
            return _craftComponents; 
        }
    }

}

using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data", order = 51)]
public abstract class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;

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

}

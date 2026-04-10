using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemController : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private GameObject _craftContaner;
    [SerializeField] private GameObject _craftCellPrefab;

    public ItemData item;

    public void UpdateUI()
    {
        ClearCraftContaner();
        _title.text = item.Name;
        _description.text = item.Desctiprion;
        _icon.sprite = item.Icon;

        foreach (CraftComponent item in item.Components) {
            CraftNeedItemCell needItem = Instantiate(_craftCellPrefab, _craftContaner.transform).GetComponent<CraftNeedItemCell>();
            needItem.component = item;
            needItem.UpdateUI();
        }

        
    }
    public void ClearCraftContaner()
    {
        foreach (Transform component in _craftContaner.GetComponentInChildren<Transform>())
        {
            Destroy(component.gameObject);
        }
    }
}

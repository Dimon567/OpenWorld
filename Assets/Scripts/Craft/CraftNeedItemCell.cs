using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftNeedItemCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemCounter;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image icon;

    public CraftComponent component;

    public void UpdateUI()
    {
        icon.sprite = component.ComponentItem.Icon;
        itemCounter.text = component.Count.ToString();
        itemName.text = component.ComponentItem.name;
    }
}

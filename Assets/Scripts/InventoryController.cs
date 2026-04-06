using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventaryManager inventary;
    [SerializeField] private GameObject _cellPrefab;

    private void Start()
    {
        UpdateUI();
        inventary.UpdateInverntaryEvent.AddListener(UpdateUI);
    }

    public void UpdateUI() {
        List<Item> items = inventary.ItemsList;
        InventaryCellController[] cells = GetComponentsInChildren<InventaryCellController>();

        for (int i = 0; i < items.Count; i++)
        {
            cells[i].DataItem = items[i];
        }
    }

    public void Clear()
    {
        InventaryCellController[] cells = GetComponentsInChildren<InventaryCellController>();

        foreach (InventaryCellController cell in cells)
        {
            cell.DataItem = null;
        }
    }
}

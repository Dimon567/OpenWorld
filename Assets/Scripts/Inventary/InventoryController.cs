using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;

    public InventoryManager inventary;
    

    private void Start()
    {
        UpdateUI();
        inventary.UpdateInverntaryEvent.AddListener(UpdateUI);
        Create();
    }

    public void UpdateUI() {
        List<Item> items = inventary.ItemsList;
        InventaryCellController[] cells = GetComponentsInChildren<InventaryCellController>();

        for (int i = 0; i < items.Count; i++)
        {
            cells[i].DataItem = items[i];
            cells[i].Select(i == inventary.SelectCell);
            
        }
    }

    public void Create()
    {
        Clear();
        List<Item> items = inventary.ItemsList;

        for (int i = 0; i < items.Count; i++)
        {
            GameObject obj = Instantiate(_cellPrefab, transform);
            obj.GetComponent<InventaryCellController>().Index = i;
        }
    }

    public void Clear()
    {
        InventaryCellController[] cells = GetComponentsInChildren<InventaryCellController>();

        foreach (InventaryCellController cell in cells)
        {
            Destroy(cell.gameObject);
        }
    }

}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Transform _inventoryContener;
    [SerializeField] private Transform _buttonsGroup;
    [SerializeField] private Button _dropButton;
    [SerializeField] private Button _equipButton;

    public InventoryManager inventary;
    

    private void Start()
    {
        UpdateUI();
        inventary.UpdateInverntaryEvent.AddListener(UpdateUI);
        _dropButton.onClick.AddListener(DropItem);
        _equipButton.onClick.AddListener(EquipItem);
        Create();
    }

    public void UpdateUI() {
        List<Item> items = inventary.ItemsList;
        InventaryCellController[] cells = _inventoryContener.GetComponentsInChildren<InventaryCellController>();

        _dropButton.gameObject.SetActive(false);
        _equipButton .gameObject.SetActive(false);

        Debug.Log(_inventoryContener.childCount);
        for (int i = 0; i < items.Count; i++)
        {
            cells[i].DataItem = items[i];

            if (inventary.SelectCell != null && i == inventary.SelectCell)
            {
                Debug.Log(i);
                cells[i].Select(true);
                Vector3 position = _buttonsGroup.transform.position;
                position = new Vector3(cells[i].transform.position.x, position.y, position.z);

                if (inventary.GetSelectItem != null)
                {
                    _dropButton.gameObject.SetActive(true);
                }
                
                continue;
            }
            
            cells[i].Select(false);
        }
    }

    public void Create()
    {
        Clear();
        List<Item> items = inventary.ItemsList;

        for (int i = 0; i < items.Count; i++)
        {
            GameObject obj = Instantiate(_cellPrefab, _inventoryContener);
            obj.GetComponent<InventaryCellController>().Index = i;
        }
    }

    public void Clear()
    {
        InventaryCellController[] cells = _inventoryContener.GetComponentsInChildren<InventaryCellController>();

        foreach (InventaryCellController cell in cells)
        {
            Destroy(cell.gameObject);
        }
    }

    public void DropItem()
    {
        Item item = inventary.ExtractItemAt(inventary.SelectCell);

        if (item == null)
        {
            return;
        }

        Vector3 position = GameManager.instance.player.transform.position;

        ItemContenerManager.instance.SpawnItem(item, position);
    }

    public void EquipItem()
    {

    }

}

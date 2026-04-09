using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> _inventary = new List<Item>(15);
    [SerializeField] private Item _tool;
    [SerializeField] private Item _head;
    [SerializeField] private Item _body;
    [SerializeField] private Item _ring;
    [SerializeField] private Item _shoes;
    [SerializeField] private Item _backpack;

    public UnityEvent UpdateInverntaryEvent = new UnityEvent();

    private int _selectCell;

    public int Count
    {
        get { return _inventary.Count; }
    }

    public int SelectCell
    {
        set {
            if (value >= 0 || value < _inventary.Count) { 
                _selectCell = value;
                UpdateInverntaryEvent?.Invoke();
            }
        }
        get { 
            return _selectCell; 
        }
    }

    public List<Item> ItemsList{
        get {  
            return new List<Item>(_inventary); 
        } 
    }

    public Item GetSelectItem
    {
        get { return _inventary[_selectCell]; }
    }

    public void RemoveItemAt(int index)
    {
        if (index < 0 || index >= _inventary.Count)
        {
            return;
        }

        _inventary[index] = null;

        UpdateInverntaryEvent?.Invoke();
    }

    public Item ExtractItemAt(int index)
    {
        if (index < 0 || index >= _inventary.Count)
        {
            return null;
        }

        Item item = _inventary[index];
        _inventary = null;

        return item;
    }

    public bool AddItem(Item item, int index)
    {
        if (!IsFree(index))
        {
            return false;
        }

        _inventary[index] = item;

        UpdateInverntaryEvent?.Invoke();
        return true;
    }

    public int? FindFreeCell()
    {
        for (int i = 0; i < _inventary.Count; i++)
        {
            if (IsFree(i))
            {
                return i;
            }
        } 

        return null;
    }

    public bool IsFree(int index)
    {
        if (index < 0 || index >= _inventary.Count)
        {
            return false;
        }

        return _inventary[index] == null;
    }

    private void OnSelectCell(int index)
    {
        SelectCell = index;
        UpdateInverntaryEvent?.Invoke();
    }

    private void OnEnable()
    {
        InventaryCellController.SelectItem.AddListener(OnSelectCell);
    }

    private void OnDisable()
    {
        InventaryCellController.SelectItem.RemoveListener(OnSelectCell);
    }
}

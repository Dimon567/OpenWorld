using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventaryManager : MonoBehaviour
{
    [SerializeField] private List<Item> _inventary = new List<Item>(15);

    public UnityEvent UpdateInverntaryEvent;

    private int _selectCell;

    public int SelectCell
    {
        set { 
            if(value >= 0 || value)
        }
    }

    public List<Item> ItemsList{
        get {  
            return new List<Item>(_inventary); 
        } 
    }

    public Item RemoveItemAt(int index)
    {
        if (index < 0 || index >= _inventary.Count)
        {
            return null;
        }

        Item item = _inventary[index];
        _inventary[index] = null;

        UpdateInverntaryEvent.Invoke();
        return item;
    }

    public bool AddItem(Item item, int index)
    {
        if (!IsFree(index))
        {
            return false;
        }

        _inventary[index] = item;

        UpdateInverntaryEvent.Invoke();
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

        if (_inventary[index] != null)
        {
            return false;
        }

        return true;
    }
}

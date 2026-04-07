using System;
using UnityEngine;

[Serializable]
public class CraftComponent
{
    [SerializeField] private ItemData _item;
    [SerializeField] private int _count;

    public ItemData ComponentItem
    {
        get { return _item; }
    }

    public int Count
    {
        get { return _count; }
    }
}

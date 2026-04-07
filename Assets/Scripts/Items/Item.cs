using NUnit.Framework;
using System.Data;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public ItemData data;

    public Item(Item other)
    {
        this.data = other.data;
    }
}

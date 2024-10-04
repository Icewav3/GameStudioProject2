using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "ScriptableObjects/PlayerInventory", order = 1)]
public class PlayerInventory : ScriptableObject
{
    [SerializeField]
    private List<Item> items = new();
    public List<Item> Items => items;

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}

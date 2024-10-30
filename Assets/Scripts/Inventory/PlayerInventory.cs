using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> items = new();
    public List<InventoryItem> Items => items;
    public static event System.Action OnInventoryUpdated;

    public void AddItem(Item item, int quantity)
    {
        foreach (var existingItem in items)
        {
            if (existingItem.Item.Equals(item))
            {
                existingItem.IncreaseQuantity(quantity);
                OnInventoryUpdated?.Invoke();
                return;
            }
        }

        items.Add(new InventoryItem(item, quantity));
        OnInventoryUpdated?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.RemoveAll(i => i.Item.Equals(item));
        OnInventoryUpdated?.Invoke();
    }

    public void UseItem(Item item, int amount)
    {
        foreach (var existingItem in items)
        {
            if (existingItem.Item.Equals(item) && existingItem.Quantity >= amount)
            {
                existingItem.DecreaseQuantity(amount);
                if (existingItem.Quantity == 0)
                {
                    items.Remove(existingItem);
                }

                OnInventoryUpdated?.Invoke();
                return;
            }
        }
    }
}
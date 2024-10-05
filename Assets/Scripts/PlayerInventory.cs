using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> items = new();
    public List<InventoryItem> Items => items;

    public void AddItem(Item item, int quantity)
    {
        foreach (var existingItem in items)
        {
            if (existingItem.Item.Equals(item))
            {
                // Increase the quantity of existing item
                existingItem.IncreaseQuantity(quantity);
                return;
            }
        }

        // Add item if it's a new unique item
        items.Add(new InventoryItem(item, quantity));
    }

    public void RemoveItem(Item item)
    {
        items.RemoveAll(i => i.Item.Equals(item));
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

                return;
            }
        }
    }
    
}
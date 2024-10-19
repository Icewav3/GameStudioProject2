using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryItem
    {
        [SerializeField]
        private Item item;
        public Item Item => item;
        [SerializeField]
        private int quantity;
        public int Quantity => quantity;

        public InventoryItem(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
        
        public void DecreaseQuantity(int amount)
        {
            quantity -= amount;
        }

        public void IncreaseQuantity(int amount)
        {
            quantity += amount;
        }
    }
}
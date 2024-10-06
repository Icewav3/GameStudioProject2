using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor
{
    public class PlayerInventoryTests
    {
        private PlayerInventory _inventory;
        private Item _item;
    
        [SetUp]
        public void SetUp()
        {
            _inventory = new GameObject().AddComponent<PlayerInventory>();
            _item = ScriptableObject.CreateInstance<Item>();
        }
    
        [Test]
        public void AddItem_ItemAddedSuccessfully()
        {
            _inventory.AddItem(_item, 5);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(_item, _inventory.Items[0].Item);
            Assert.AreEqual(5, _inventory.Items[0].Quantity);
        }

        [Test]
        public void AddItem_IncreaseQuantityOfExistingItem()
        {
            _inventory.AddItem(_item, 5);
            _inventory.AddItem(_item, 3);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(8, _inventory.Items[0].Quantity);
        }
    }
}
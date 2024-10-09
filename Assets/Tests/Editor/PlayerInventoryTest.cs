using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor
{
    /// <summary>
    /// Basically all this class does is allow us to test to make sure the inventory system works
    /// and handles a bunch of edge cases
    /// </summary>
    /// <remarks>
    /// I wanted to learn a bit about unit testing in unity, so I spent some time learning about them and trying them here
    /// </remarks>
    public class PlayerInventoryTests
    {
        private PlayerInventory _inventory;
        private Item _item1;
        private Item _item2;

        [SetUp]
        public void SetUp()
        {
            _inventory = new GameObject().AddComponent<PlayerInventory>();
            _item1 = ScriptableObject.CreateInstance<Item>();
            _item2 = ScriptableObject.CreateInstance<Item>();
        }

        [Test]
        public void AddItem_ItemAddedSuccessfully()
        {
            _inventory.AddItem(_item1, 5);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(_item1, _inventory.Items[0].Item);
            Assert.AreEqual(5, _inventory.Items[0].Quantity);
        }

        [Test]
        public void AddItem_IncreaseQuantityOfExistingItem()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.AddItem(_item1, 3);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(8, _inventory.Items[0].Quantity);
        }

        [Test]
        public void RemoveItem_ItemRemovedSuccessfully()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.RemoveItem(_item1);
            Assert.AreEqual(0, _inventory.Items.Count);
        }

        [Test]
        public void UseItem_DecreaseQuantity()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.UseItem(_item1, 3);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(2, _inventory.Items[0].Quantity);
        }

        [Test]
        public void UseItem_RemoveItemWhenQuantityZero()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.UseItem(_item1, 5);
            Assert.AreEqual(0, _inventory.Items.Count);
        }

        [Test]
        public void UseItem_UseMoreThanAvailableQuantity()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.UseItem(_item1, 10);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(5, _inventory.Items[0].Quantity);
        }

        [Test]
        public void AddMultipleUniqueItems()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.AddItem(_item2, 3);
            Assert.AreEqual(2, _inventory.Items.Count);
            Assert.AreEqual(_item1, _inventory.Items[0].Item);
            Assert.AreEqual(_item2, _inventory.Items[1].Item);
        }

        [Test]
        public void RemoveItemAndAddAgain()
        {
            _inventory.AddItem(_item1, 5);
            _inventory.RemoveItem(_item1);
            _inventory.AddItem(_item1, 3);
            Assert.AreEqual(1, _inventory.Items.Count);
            Assert.AreEqual(_item1, _inventory.Items[0].Item);
            Assert.AreEqual(3, _inventory.Items[0].Quantity);
        }

        [Test]
        public void RemoveNonExistentItem()
        {
            _inventory.RemoveItem(_item1);
            Assert.AreEqual(0, _inventory.Items.Count);
        }
    }
}
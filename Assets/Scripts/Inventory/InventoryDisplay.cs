using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private GameObject[] slots;

        private void Start()
        {
            if (playerInventory == null)
            {
                playerInventory = FindObjectOfType<PlayerInventory>();
            }

            if (slots == null || slots.Length == 0)
            {
                slots = new GameObject[5];
                for (int i = 0; i < slots.Length; i++)
                {
                    slots[i] = transform.Find($"slot{i + 1}").gameObject;
                }
            }

            UpdateInventoryDisplay();
        }

        private void UpdateInventoryDisplay()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < playerInventory.Items.Count)
                {
                    var item = playerInventory.Items[i];
                    var spriteRenderer = slots[i].GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = item.Item.Sprite;
                    }
                }
                else
                {
                    var spriteRenderer = slots[i].GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = null;
                    }
                }
            }
        }

        private void OnEnable()
        {
            PlayerInventory.OnInventoryUpdated += UpdateInventoryDisplay;
        }

        private void OnDisable()
        {
            PlayerInventory.OnInventoryUpdated -= UpdateInventoryDisplay;
        }
    }
}
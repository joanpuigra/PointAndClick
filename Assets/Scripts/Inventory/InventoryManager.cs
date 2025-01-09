using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Button> itemSlots;
    private bool isActive = false;
    public string itemName = "";
    [SerializeField] private GameObject inventory;
    private BoxCollider2D boxCollider2D;

    // Add item to inventory
    public void AddItem(SpriteRenderer itemSprite, string pItemName)
    {
        Debug.Log("Added item to inventory: " + pItemName);
        for (int i = 0; i < itemSlots.Count; i++)
        {
            // If slot is empty, add item
            var slotButton = itemSlots[i];
            if (slotButton == null)
            {
                Debug.Log("Slot button at index " + i + " is null");
                continue;
            }

            var slotSpriteRenderer = slotButton.GetComponent<SpriteRenderer>();
            if (slotSpriteRenderer == null)
            {
                Debug.Log("Slot " + i + " does not have a sprite renderer");
                continue;
            }
            if (slotSpriteRenderer.sprite == null)
            {
                slotSpriteRenderer.sprite = itemSprite.sprite;
             
                // Adjust the size of the sprite
                RectTransform rt = slotButton.GetComponent<RectTransform>();
                if (rt != null)
                {
                    float buttonWidth = rt.rect.width;
                    float buttonHeight = rt.rect.height;
                    float spriteWidth = slotSpriteRenderer.sprite.bounds.size.x;
                    float spriteHeight = slotSpriteRenderer.sprite.bounds.size.y;

                    float xScale = buttonWidth / spriteWidth;
                    float yScale = buttonHeight / spriteHeight;
                    float scale = Mathf.Min(xScale, yScale);

                    slotSpriteRenderer.transform.localScale = new Vector3(scale, scale, 1);
                }
             
                // Set the item name
                var itemInventory = itemSlots[i].GetComponent<ItemInventory>();
                if (itemInventory == null)
                {
                    Debug.Log("Slot " + i + " is missing ItemInventory component");
                    continue;
                }
                itemInventory.SetItemName(pItemName);

                // Set collider active
                boxCollider2D = itemSlots[i].GetComponent<BoxCollider2D>();
                if (boxCollider2D == null)
                {
                    Debug.Log("Slot " + i + " is missing BoxCollider2D component");
                    continue;
                }
                boxCollider2D.enabled = true;
                
                Debug.Log("Item added to slot: " + i);
                break;
            }
            else
            {
                Debug.Log("Slot is not empty: " + i);
            }
        }
    }

    public string GetButtonPressed()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            // If slot is empty, add item
            if (itemSlots[i].GetComponent<ItemInventory>().GetIsActiveButton())
            {
                itemName = itemSlots[i].GetComponent<ItemInventory>().GetItemName();
            }
        }
        return itemName;
    }

    public void ResetInventoryButtons()
    {
        itemName = "";
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].GetComponent<ItemInventory>().ResetButton();
        }
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].GetComponent<ItemInventory>().GetItemName() == itemName)
            {
                itemSlots[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                itemSlots[i].GetComponent<SpriteRenderer>().sprite = null;
                itemSlots[i].GetComponent<BoxCollider2D>().enabled = false;
                itemSlots[i].GetComponent<ItemInventory>().SetItemName("Slot" + i);
                break;
            }
        }
    }

    public void ShowInventory()
    {
        isActive = !isActive;
        inventory.SetActive(isActive);
    }
}
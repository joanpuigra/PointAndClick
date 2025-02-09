using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public bool isActive = false;
    public string itemName;
    public GameObject gameManager;

    private ButtonsBehaviour buttons;
    private InventoryManager inventoryManager;
    private DialogueManager dialog;
    private GameObject inventoryNode;
    private BoxProperties boxProperties;
    private FlareAnimation flare;

    void Start()
    {
        buttons = gameManager.GetComponent<ButtonsBehaviour>();
        dialog = gameManager.GetComponent<DialogueManager>();
        flare = GameObject.FindGameObjectWithTag("Arm").GetComponent<FlareAnimation>();
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        boxProperties = GameObject.FindGameObjectWithTag("Box").GetComponent<BoxProperties>();
    }

    public void UseItem()
    {
        isActive = true;
        if (itemName == "Coco")
        {
            dialog.ShowMessage(1, "Interaction");
            inventoryManager.RemoveItem(itemName);
            buttons.ResetButtons();
            inventoryManager.ResetInventoryButtons();
        }
        if (itemName == "Rama")
        {
            dialog.ShowMessage(4, "Interaction");
            inventoryManager.RemoveItem(itemName);
            buttons.ResetButtons();
            inventoryManager.ResetInventoryButtons();
            boxProperties.MoveBox();
        }
        if (itemName == "Bengala")
        {
            dialog.ShowMessage(3, "Interaction");
            inventoryManager.RemoveItem(itemName);
            buttons.ResetButtons();
            inventoryManager.ResetInventoryButtons();
            flare.ActivateAnimation();
        }
    }

    public bool GetIsActiveButton()
    {
        return isActive;
    }

    public void ResetButton()
    {
        isActive = false;
    }

    public void SetItemName(string itemName)
    {
        this.itemName = itemName;
        this.gameObject.name = itemName;
    }

    public string GetItemName()
    {
        return itemName;
    }
}
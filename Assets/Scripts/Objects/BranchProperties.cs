using UnityEngine;

public class BranchProperties : MonoBehaviour
{
    private Vector2 mousePosition;
    private ButtonsBehaviour buttons;
    private InventoryManager inventoryManager;
    private DialogueManager dialog;
    public GameObject gameManager;
    public GameObject inventory;
    public bool isActive = false;
    public string itemName = "Rama";


    void Start()
    {
        buttons = gameManager.GetComponent<ButtonsBehaviour>();
        dialog = gameManager.GetComponent<DialogueManager>();
        inventoryManager = inventory.GetComponent<InventoryManager>();
    }

    void Update()
    {
        CheckButtonDown();
    }

    private void CheckButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Check if the object is the same with the script
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnMouseClick();
            }
        }
    }

    private void OnMouseClick()
    {
        if (buttons.GetBtnLook())
        {
            dialog.ShowMessage(4, "Look");
            buttons.ResetButtons();
        }
        if (buttons.GetBtnUse())
        {
            dialog.ShowMessage(4, "Use");
            buttons.ResetButtons();
        }
        if (!isActive && buttons.GetBtnTake())
        {
            isActive = true;
            dialog.ShowMessage(4, "Take");
            inventoryManager.AddItem(
                this.GetComponent<SpriteRenderer>(),
                itemName
            );
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            this.GetComponent<SpriteRenderer>().sprite = null;
            this.GetComponent<BoxCollider2D>().enabled = false;
            buttons.ResetButtons();
        }
    }
}

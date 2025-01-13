using UnityEngine;

public class FlareGunProperties : MonoBehaviour
{
    private Vector2 mousePosition;
    public GameObject gameManager;
    public GameObject inventory;
    private InventoryManager inventoryManager;
    private ButtonsBehaviour buttons;
    private DialogueManager dialog;
    public bool isActive = false;
    public string itemName = "Bengala";

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

    public void AddFlareGun()
    {
        inventoryManager.AddItem(
            this.GetComponent<SpriteRenderer>(),
            itemName
        );
    }

    private void OnMouseClick()
    {
        if (buttons.GetBtnLook())
        {
            dialog.ShowMessage(2, "Look");
        }
        if (buttons.GetBtnUse())
        {
            dialog.ShowMessage(2, "Use");
        }
        if (buttons.GetBtnTake())
        {
            dialog.ShowMessage(2, "Take");
        }
    }
}


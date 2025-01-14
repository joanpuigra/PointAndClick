using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    private Vector2 mousePosition;
    public GameObject gameManager;
    private ButtonsBehaviour buttons;
    private DialogueManager dialog;
    public SpriteRenderer newSprite;
    public bool isActive = false;

    void Start()
    {
        buttons = gameManager.GetComponent<ButtonsBehaviour>();
        dialog = gameManager.GetComponent<DialogueManager>();
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
            dialog.ShowMessage(3, "Look");
        }
        if (buttons.GetBtnUse())
        {
            dialog.ShowMessage(3, "Use");
        }
        if (buttons.GetBtnTake())
        {
            dialog.ShowMessage(3, "Take");
        }
    }

    public void UseFlareGun()
    {
        isActive = true;
        this.GetComponent<SpriteRenderer>().sprite = this.newSprite.sprite;
    }
}

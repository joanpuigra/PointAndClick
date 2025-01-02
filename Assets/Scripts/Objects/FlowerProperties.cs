using UnityEngine;

public class FlowerProperties : MonoBehaviour
{
    public bool isActive = false;
    private Vector2 mousePosition;
    public GameObject gameManager;
    private ButtonsBehaviour buttons;
    private Animator animator;
    private DialogueManager dialog;

    void Start()
    {
        buttons = gameManager.GetComponent<ButtonsBehaviour>();
        dialog = gameManager.GetComponent<DialogueManager>();
        animator = GetComponent<Animator>();
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
            dialog.ShowMessage(0, "Look");
        }
        if (!isActive && buttons.GetBtnUse())
        {
            isActive = true;
            animator.SetBool("isActive", isActive);
            dialog.ShowMessage(0, "Use");
        }
        if (buttons.GetBtnTake())
        {
            dialog.ShowMessage(0, "Take");
        }
    }
}

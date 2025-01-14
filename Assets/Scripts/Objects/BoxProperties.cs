using UnityEngine;

public class BoxProperties : MonoBehaviour
{
    private Vector2 mousePosition;
    public GameObject gameManager;
    public GameObject inventory;
    public FlareGunProperties flareGun;
    private ButtonsBehaviour buttons;
    private DialogueManager dialog;
    public bool movedBox = false;
    public bool isActive = false;

    void Start()
    {
        buttons = gameManager.GetComponent<ButtonsBehaviour>();
        dialog = gameManager.GetComponent<DialogueManager>();
        flareGun = GameObject.FindGameObjectWithTag("FlareGun").GetComponent<FlareGunProperties>();
    }

    void Update()
    {
        CheckButtonDown();
    }

    public void MoveBox()
    {
        if (!movedBox)
        {
            Transform box = this.gameObject.transform;
            box.position = new Vector3(2.5f, -1.5f, 1.0f);
            movedBox = true;
        }
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
        if (!isActive && movedBox && buttons.GetBtnTake())
        {
            isActive = true;
            dialog.ShowMessage(2, "Interaction");
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            this.GetComponent<SpriteRenderer>().sprite = null;
            this.GetComponent<BoxCollider2D>().enabled = false;
            flareGun.AddFlareGun();
        }
    }
}

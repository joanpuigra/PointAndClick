using UnityEngine;
using UnityEngine.EventSystems;

public class CoconutProperties : MonoBehaviour
{
    public bool isActive = false;
    public GameObject eventSystem;
    private ButtonsBehavior buttonsBehavior;

    void Start()
    {
        buttonsBehavior = eventSystem.GetComponent<ButtonsBehavior>();
    }

    private void Update()
    {
        CheckButtonDown();
    }

    private void CheckButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnMouseClick();
            }
        }
    }

    public void OnMouseClick()
    {
        if (!isActive && buttonsBehavior.ButtonClicked == 0)
        {
            buttonsBehavior.HandleButton(this.gameObject, 0);
        }
        else if (!isActive && buttonsBehavior.ButtonClicked == 1)
        {
            isActive = true;
            buttonsBehavior.HandleButton(this.gameObject, 1);
        }
        else if (isActive && buttonsBehavior.ButtonClicked == 1)
        {
            buttonsBehavior.HandleButton(this.gameObject, 1);
        }
        else if (!isActive && buttonsBehavior.ButtonClicked == 2)
        {
            buttonsBehavior.HandleButton(this.gameObject, 2);
        }
    }
}

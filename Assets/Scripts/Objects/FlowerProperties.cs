using UnityEditor.Build.Content;
using UnityEngine;

public class FlowerProperties : MonoBehaviour
{
    public bool isActive = false;
    public GameObject eventSystem;

    private ButtonsBehavior buttonsBehavior;
    private Animator animator;

    void Start()
    {
        buttonsBehavior = eventSystem.GetComponent<ButtonsBehavior>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        CheckButtonDown();
    }

    public void CheckButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Object: " + hit.collider.gameObject.name + " gameObject: " + gameObject.name);
                OnMouseClick();
            }
        }
    }

    public void OnMouseClick()
    {
        // if (!isActive && buttonsBehavior.ButtonClicked == 0)
        if (!isActive && buttonsBehavior.GetLookButton())
        {
            buttonsBehavior.HandleButton(this.eventSystem, 0);
        }
        // else if (!isActive && buttonsBehavior.ButtonClicked == 1)
        else if (!isActive && buttonsBehavior.GetUseButton())
        {
            isActive = true;
            animator.SetBool("isUsed", true);
            buttonsBehavior.HandleButton(this.eventSystem, 1);
        }
        // else if (isActive && buttonsBehavior.ButtonClicked == 1)
        else if (isActive && buttonsBehavior.GetUseButton())
        {
            buttonsBehavior.HandleButton(this.eventSystem, 1);
        }
        // else if (!isActive && buttonsBehavior.ButtonClicked == 2)
        else if (!isActive && buttonsBehavior.GetTakeButton())
        {
            buttonsBehavior.HandleButton(this.eventSystem, 2);
        }
    }
}

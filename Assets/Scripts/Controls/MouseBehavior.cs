using UnityEngine;
using UnityEngine.EventSystems;

public class MouseBehavior : MonoBehaviour
{
    private FlowerProperties flowerProperties;
    private PlayerProperties playerProperties;
    private CoconutProperties coconutProperties;
    private BoxProperties boxProperties;


    public ButtonsBehavior buttonsBehavior;
    private PointerEventData pointerData;
    private Ray ray;
    private RaycastHit2D hit;

    void Start()
    {
        flowerProperties = GetComponent<FlowerProperties>();
        playerProperties = GetComponent<PlayerProperties>();
        coconutProperties = GetComponent<CoconutProperties>();
        boxProperties = GetComponent<BoxProperties>();

        GameObject eventSystem = GameObject.Find("GameManager");

        if (eventSystem != null)
        {
            buttonsBehavior = eventSystem.GetComponent<ButtonsBehavior>();
            if (buttonsBehavior == null)
            {
                Debug.LogError("ButtonsBehavior not found");
            }
        }
        else
        {
            Debug.LogError("GameManager not found");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectObjectClick(new PointerEventData(EventSystem.current));
        }
    }

    // region Mouse position detection
    // private void UpdateMousePosition()
    // {
    //     mousePosition = Input.mousePosition;
    //     if (mousePosition != Vector2.zero)
    //     {
    //         worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
    //         ray = new Ray2D(worldPoint, Vector2.down);
    //         hit = Physics2D.Raycast(ray.origin, ray.direction);

    //         Debug.Log("Ray: " + ray + "Hit: " + hit);

    //         if (hit.collider != null && hit.collider.CompareTag("ClickableZone"))
    //         {
    //             selectedObject = hit.collider.gameObject;
    //             Debug.Log("Hit object: " + selectedObject.name);
    //         }
    //     }
    // }
    // endregion

    public void DetectObjectClick(BaseEventData data)
    {
        pointerData = (PointerEventData)data;
        ray = Camera.main.ScreenPointToRay(pointerData.position);
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (gameObject.name == "Flower")
            {
                flowerProperties.OnMouseClick();
            }
            else if (gameObject.name == "Coconut")
            {
                coconutProperties.OnMouseClick();
            }
            else if (gameObject.name == "Box")
            {
                boxProperties.OnMouseClick();
            }
            else if (gameObject.name == "Player")
            {
                playerProperties.OnMouseClick();
            }
        }
    }

    // void OnGUI()
    // {
    //     GUI.Label(new Rect(10, 10, 300, 20), "Mouse position: " + pointerData.position);
    //     GUI.Label(new Rect(10, 50, 300, 20), "Ray: " + ray);
    //     GUI.Label(new Rect(10, 50, 300, 20), "RayCast: " + hit);
    //     GUI.Label(new Rect(10, 100, 300, 20), "World: " + worldPoint);
    // }
}

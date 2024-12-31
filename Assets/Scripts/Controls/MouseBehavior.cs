using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    private GameObject selectedObject;
    private Vector2 mousePosition;

    private void Update()
    {
        DetectMousePosition();
    }

    private void DetectMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            selectedObject = hit.collider.gameObject;
            mousePosition = Camera.main.WorldToScreenPoint(selectedObject.transform.position);
        }
        else
        {
            selectedObject = null;
        }
    }

    private void OnGUI()
    {
        GUIStyle guiStyle = new()
        {
            fontSize = 50,
            fontStyle = FontStyle.Bold,
            padding = new RectOffset(5, 5, 5, 5),
            alignment = TextAnchor.LowerCenter,
        };

        guiStyle.normal.textColor = Color.black;

        if (selectedObject != null)
        {
            GUI.Label(new Rect(mousePosition.x, Screen.height - mousePosition.y + 5, 10, 20), selectedObject.name, guiStyle);
            GUI.Label(new Rect(mousePosition.x, Screen.height - mousePosition.y - 5, 10, 20), selectedObject.name, guiStyle);
            GUI.Label(new Rect(mousePosition.x + 5, Screen.height - mousePosition.y, 10, 20), selectedObject.name, guiStyle);
            GUI.Label(new Rect(mousePosition.x - 5, Screen.height - mousePosition.y, 10, 20), selectedObject.name, guiStyle);

            guiStyle.normal.textColor = Color.yellow;
            GUI.Label(new Rect(mousePosition.x, Screen.height - mousePosition.y, 10, 20), selectedObject.name, guiStyle);
        }
    }
}
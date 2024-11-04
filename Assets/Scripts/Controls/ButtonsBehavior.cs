using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsBehavior : MonoBehaviour
{
    private GameObject btnLook;
    private GameObject btnUse;
    private GameObject btnTake;
    private DialogueManager dialog;
    private bool isButtonLookClicked = false;
    private bool isButtonUseClicked = false;
    private bool isButtonTakeClicked = false;

    public int ButtonClicked { get; set; }

    private void Start()
    {
        btnLook = GameObject.Find("BtnLook");
        btnUse = GameObject.Find("BtnUse");
        btnTake = GameObject.Find("BtnTake");

        btnLook.GetComponent<Button>().interactable = true;
        btnUse.GetComponent<Button>().interactable = true;
        btnTake.GetComponent<Button>().interactable = true;
    }

    public bool GetLookButton()
    {
        return isButtonLookClicked;
    }

    public bool GetUseButton()
    {
        return isButtonUseClicked;
    }

    public bool GetTakeButton()
    {
        return isButtonTakeClicked;
    }

    public void OnLookButtonClicked()
    {
        ButtonClicked = 0;
        btnUse.GetComponent<Button>().interactable = false;
        btnTake.GetComponent<Button>().interactable = false;
        isButtonLookClicked = true;
        isButtonUseClicked = false;
        isButtonTakeClicked = false;
        // ResetButtons();
    }

    public void OnUseButtonClicked()
    {
        ButtonClicked = 1;
        btnLook.GetComponent<Button>().interactable = false;
        btnTake.GetComponent<Button>().interactable = false;
        isButtonLookClicked = false;
        isButtonUseClicked = true;
        isButtonTakeClicked = false;
        // ResetButtons();
    }

    public void OnTakeButtonClicked()
    {
        ButtonClicked = 2;
        btnLook.GetComponent<Button>().interactable = false;
        btnUse.GetComponent<Button>().interactable = false;
        isButtonLookClicked = false;
        isButtonUseClicked = false;
        isButtonTakeClicked = true;
        // ResetButtons();
    }

    public void ResetButtons()
    {
        btnLook.GetComponent<Button>().interactable = true;
        btnUse.GetComponent<Button>().interactable = true;
        btnTake.GetComponent<Button>().interactable = true;

        isButtonLookClicked = true;
        isButtonUseClicked = true;
        isButtonTakeClicked = true;
    }

    public void HandleButton(GameObject clickedObject, int buttonClicked)
    {
        string action = buttonClicked == 0 ? "Look" : buttonClicked == 1 ? "Use" : "Take";
        string messageIndex = clickedObject.name switch
        {
            "Flower" => "0",
            "Coconut" => "1",
            "Box" => "2",
            "Player" => "3",
            _ => throw new System.NotImplementedException(),
        };

        if (messageIndex != null && dialog != null)
        {
            dialog.ShowMessage(messageIndex, action);
        }
    }
}

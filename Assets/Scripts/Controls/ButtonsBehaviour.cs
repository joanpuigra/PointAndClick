using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    private bool btnLook = false;
    private bool btnUse = false;
    private bool btnTake = false;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
    }

    public bool GetBtnLook()
    {
        return btnLook;
    }

    public bool GetBtnUse()
    {
        return btnUse;
    }

    public bool GetBtnTake()
    {
        return btnTake;
    }

    public void Look()
    {
        ResetButtons();
        btnLook = true;
    }

    public void Use()
    {
        ResetButtons();
        btnUse = true;
    }

    public void Take()
    {
        ResetButtons();
        btnTake = true;
    }

    public void ResetButtons()
    {
        btnLook = false;
        btnUse = false;
        btnTake = false;
    }
}
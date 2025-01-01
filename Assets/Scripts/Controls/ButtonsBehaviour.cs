using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    private bool btnLook = false;
    private bool btnUse = false;
    private bool btnTake = false;

    private void Start()
    {
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
        if (!btnLook)
        {
            btnLook = true;
            btnTake = false;
            btnUse = false;
        }
        else
        {
            btnLook = false;
        }
    }

    public void Use()
    {
        if (!btnUse)
        {
            btnUse = true;
            btnTake = false;
            btnLook = false;
        }
        else
        {
            btnUse = false;
        }
    }

    public void Take()
    {
        if (!btnTake)
        {
            btnTake = true;
            btnUse = false;
            btnLook = false;
        }
        else
        {
            btnTake = false;
        }
    }

    public void ResetButtons()
    {
        btnLook = false;
        btnUse = false;
        btnTake = false;
    }
}
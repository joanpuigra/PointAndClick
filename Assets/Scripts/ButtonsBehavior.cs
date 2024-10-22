using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehavior : MonoBehaviour
{
    private bool useButton = false;

    public bool GetUseButton()
    {
        return useButton;
    }

    public void ButtonLook()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Look Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Look Unpressed");
        }
    }

    public void ButtonUse()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Use Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Use Unpressed");
        }
    }

    public void ButtonTake()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Take Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Take Unpressed");
        }
    }

    public void ButtonOpen()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Open Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Open Unpressed");
        }
    }

    public void ButtonClose()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Close Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Close Unpressed");
        }
    }


    public void ButtonTalk()
    {
        if (!useButton)
        {
            useButton = true;
            Debug.Log("Button Talk Pressed");
        }
        else
        {
            useButton = false;
            Debug.Log("Button Talk Unpressed");
        }
    }
}

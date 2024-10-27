using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowerProperties : MonoBehaviour, IPointerClickHandler
{
    public bool isActive = false;
    public GameObject eventSystem;

    private ButtonsBehavior buttonsBehavior;
    private Animator animator;
    private DialogueManager dialogue;
    // public string textDialog;

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehavior = eventSystem.GetComponent<ButtonsBehavior>();
        animator = this.GetComponent<Animator>();
        dialogue = eventSystem.GetComponent<DialogueManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isActive && buttonsBehavior.GetUseButton())
        {
            isActive = true;
            animator.SetBool("isUsed", true);
        }
    }
}

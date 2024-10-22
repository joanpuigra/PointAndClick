using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowerProperties : MonoBehaviour, IPointerClickHandler
{
    public bool isActive = false;
    public GameObject eventSystem;

    private ButtonsBehavior buttonsBehavior;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehavior = eventSystem.GetComponent<ButtonsBehavior>();
        animator = this.GetComponent<Animator>();
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

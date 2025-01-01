using UnityEngine;

public class FlowerProperties : MonoBehaviour
{
    public bool isActive = false;

    private Animator animator;
    private DialogueManager dialog;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}

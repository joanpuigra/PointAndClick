using UnityEngine;

public class FlowerProperties : MonoBehaviour
{
    public bool isActive = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}

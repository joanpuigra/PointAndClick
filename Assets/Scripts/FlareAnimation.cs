using UnityEngine;

public class FlareAnimation : MonoBehaviour
{
    public bool isActive = false;
    private Animator animator;
    public PlayerProperties player;
    public GameObject flareGun;
    public GameObject flareBullet;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }

    public void ActivateAnimation()
    {
        if (!player.isActive) {
            this.GetComponent<SpriteRenderer>().enabled = true;
            player.UseFlareGun();
            flareGun.GetComponent<SpriteRenderer>().enabled = true;
            isActive = true;
            animator.SetBool("isActive", isActive);
        }
    }

    public void ShootFlare()
    {
        flareBullet.GetComponent<FlareShoot>().ShootFlare();
    }
}

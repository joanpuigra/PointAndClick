using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlareShoot : MonoBehaviour
{
    public bool isActive = false;
    private Transform flare;
    public GameObject flareSparks;
    public GameObject flareTrail;
    public GameObject flareSound;
    public float speed = 5f;
    public float targetBullet = 5f;
    public float delay = 3f;

    void Start()
    {
        flare = GetComponent<Transform>();
    }


    void Update()
    {
        if (isActive)
        {
            MoveBullet();
            if (flare.position.y == targetBullet)
            {
                isActive = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
                flareSparks.GetComponent<ParticleSystem>().Stop();
                StartCoroutine(ChangeScene());
            }
        }
    }

    public void ShootFlare()
    {
        if (!isActive) {
            this.GetComponent<SpriteRenderer>().enabled = true;
            flareSparks.GetComponent<ParticleSystem>().Play();
            flareSound.GetComponent<AudioSource>().Play();
            isActive =  true;
        }
    }

    private void MoveBullet()
    {
        Vector2 newPosition = flare.position;
        newPosition.y = Mathf.MoveTowards(flare.position.y, targetBullet, speed * Time.deltaTime);
        flare.position = newPosition;
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("End_Game");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject firePoint;
    public GameObject explosion;
    public GameObject spawner;
    public GameObject coinCounter;
    public GameObject UI;
    public GameObject DeathScreen;
    public AudioClip shootSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    public float height = 20f;
    public float movementSpeed = 10f;
    public float fireRate = 5f;
    public float health = 100f;

    float fireDelay = 0f;
    float shootCheck = 0f;
    // Start is called before the first frame update
    void Start()
    {
        fireDelay = 1/fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            touchPosition.y = height;
            transform.position = Vector3.Lerp(transform.position, touchPosition, movementSpeed * Time.deltaTime);
            shootCheck += Time.deltaTime;
            if(shootCheck >= fireDelay)
            {
                shootCheck = 0f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        Vector3 sound;
        sound.x = 0;
        sound.y = 0;
        sound.z = 0;
        AudioSource.PlayClipAtPoint(shootSound, sound, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Obstacle")
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();
            if(obstacle != null)
            {
                obstacle.Die(false);
                Die();
            }
        }
        else if(other.gameObject.tag == "Coin")
        {
            Vector3 sound;
            sound.x = 0;
            sound.y = 0;
            sound.z = 0;
        AudioSource.PlayClipAtPoint(coinSound, sound);
            Destroy(other.gameObject);
            coinCounter.GetComponent<CoinCounter>().addCoin();
        }
        
    }
    public void Die()
    {
        Vector3 sound;
        sound.x = 0;
        sound.y = 0;
        sound.z = 0;
        AudioSource.PlayClipAtPoint(explosionSound, sound);
        Score score = GetComponent<Score>();
        Debug.Log("DEAD");
        Debug.Log("Final Score: " + score.score.ToString());
        GetComponent<Score>().stopCounting();
        spawner.SetActive(false);
        UI.SetActive(false);
        DeathScreen.SetActive(true);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
}

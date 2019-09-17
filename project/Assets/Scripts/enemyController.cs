using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public float initfireRate = 2f;
    float fireRate;
    public float speed = 10f;
    public float maxX = 40f;
    public GameObject bullet;
    public GameObject firePoint;
    public AudioClip shootSound;
    public AudioClip explosionSound;
    public GameObject explosion;
    public int spawnerNumber;
    Transform targetPosition;
    public float damp = 5;
    float fireDelay = 0f;
    float shootCheck = 0f;
    public float health = 300f;
    float y;
    Spawner spawner;

    Score score;
    void Start() 
    {
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        spawner.bossIsSpawned = true;
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        int wavenumber = score.score/150;
        if(wavenumber > 1)
        {
            fireRate = initfireRate * wavenumber*1.2f;
        }
        else
        {
            fireRate = initfireRate;
        }
        fireDelay = 1/fireRate;
        y = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        spawner.bossSpawn = true;
        spawner.bossIsSpawned = true;
        if ( targetPosition ) // we get sure the target is here
        {
            Vector2 direction = new Vector2(targetPosition.position.x - transform.position.x, targetPosition.position.y - transform.position.y);
            transform.up = direction;
        }
        if(spawnerNumber == 8)
        {
            transform.position = new Vector2 (Mathf.Lerp(transform.position.x,maxX * Mathf.Sin(Time.time*speed), Time.deltaTime * speed), y);
        }
        if(spawnerNumber == 9)
        {
            transform.position = new Vector2 (Mathf.Lerp(transform.position.x,-maxX * Mathf.Sin(Time.time*speed), Time.deltaTime * speed), y);
        }
        shootCheck += Time.deltaTime;
        if(shootCheck >= fireDelay)
        {
            shootCheck = 0f;
            Shoot();
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        spawner.bossSpawn = false;
        spawner.bossIsSpawned = false;
        score.addScore(20);
        Vector3 sound;
        sound.x = 0;
        sound.y = 0;
        sound.z = 0;
        AudioSource.PlayClipAtPoint(explosionSound, sound);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    public GameObject impactEffect;
    public AudioClip impactSound;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D other) {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        enemyController enemy = other.GetComponent<enemyController>();
        if(obstacle != null)
        {
            Vector3 sound;
            sound.x = 0;
            sound.y = 0;
            sound.z = 0;
            AudioSource.PlayClipAtPoint(impactSound, sound, 0.7f);
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            obstacle.TakeDamage(damage);
            Destroy(gameObject);
            Destroy(impact, 0.05f);
        }
        if(enemy != null)
        {
            Vector3 sound;
            sound.x = 0;
            sound.y = 0;
            sound.z = 0;
            AudioSource.PlayClipAtPoint(impactSound, sound, 0.7f);
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Destroy(impact, 0.05f);
        }
    }
    
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

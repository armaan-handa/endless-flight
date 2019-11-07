using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float initspeed = 20f;
    float speed;
    public float maxSpeed = 70f;
    //public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impactEffect;
    public AudioClip impactSound;
    public Rigidbody2D rb;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        int wavenumber = score.score/150;
        if(wavenumber > 1) // controls the speed of rhe bullet depending on the wavenumber of the enemies.
        {
            speed = initspeed * wavenumber*1.5f;
            if(speed > maxSpeed)    // makes sure bullet does not go above the maximum speed
            {
                speed = maxSpeed;
            }
        }
        else
        {
            speed = initspeed;
        }
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if(pc != null)  // will play the correct audio clip and impact effect and make the player take damage.
        {
            Vector3 sound;
            sound.x = 0;
            sound.y = 0;
            sound.z = 0;
            AudioSource.PlayClipAtPoint(impactSound, sound, 0.7f);
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            pc.TakeDamage(damage);
            Destroy(gameObject);
            Destroy(impact, 0.05f);
        }
    }
    
    void OnBecameInvisible() { // destroy game object when bullet leaves the screen.
        Destroy(gameObject);
    }
}

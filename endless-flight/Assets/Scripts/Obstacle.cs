using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject explosion;
    public GameObject coin;
    public float dropChance = 5f;
    private GameObject player;
    private Score score;

    public float speed = 10f;
    public float health = 100f;
    public AudioClip explosionSound;
    
    //public GameObject light;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        score = player.GetComponent<Score>();
    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        //Light2D _light = light.GetComponent<Light2D>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die(true);
        }
    }
    public void Die(bool fromBullet)
    {
        if(fromBullet)
        {
            score.addScore(4);
            Vector3 sound; 
            sound.x = 0;
            sound.y = 0;
            sound.z = 0;
            AudioSource.PlayClipAtPoint(explosionSound, sound);
            Debug.Log(score.score.ToString());
        }
        int coinDrop = Mathf.RoundToInt(Random.Range(1, dropChance));
        if(coinDrop == 1)
        {
            GameObject coinObject = Instantiate(coin, transform.position, transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnBecameInvisible() 
    {
        score.addScore(1);
        Debug.Log(score.score.ToString());
        Destroy(gameObject);
    }

    void OnBecameVisible() 
    {
       BoxCollider2D bc = GetComponent<BoxCollider2D>();
       bc.enabled = true;
    }
}

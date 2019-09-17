using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}

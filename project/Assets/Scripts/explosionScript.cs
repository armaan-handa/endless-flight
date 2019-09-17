using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    float time = 0f;

    // Update is called once per frame
    void Update()
    {  
       if(time >= 0.5)
       {
           Destroy(gameObject);
       } 
       else 
       {
           time+= Time.deltaTime;
       }
    }
}

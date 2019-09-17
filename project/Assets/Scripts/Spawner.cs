using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] sp;
    public GameObject Obstacle;
    public GameObject Enemy;
    public float TimeBtwSpawn = 2f;
    float counter = 2f;
    public float decreaseTime = 0.05f;
    public float minTime = 0.3f;
    public float distBtwSpawn = 7f;
    public float shouldDecreaseCount = 5f;
    private int spawnLimit;
    public int shouldDecrease;
    public Score score;
    public bool bossSpawn = false;
    public bool bossIsSpawned = false;
    // Update is called once per frame
    void Update()
    {
        int wavenumber = score.score/150;
        if(score.score % 150 >= 0 && score.score % 150 < 5 && score.score > 149)
        {
            bossSpawn = true;
        }
        if(bossSpawn)
        {
            if(!bossIsSpawned)
            {
                bossIsSpawned = true;
                GameObject enemy1 = Instantiate(Enemy, sp[8].transform.position, transform.rotation);
                GameObject enemy2 = Instantiate(Enemy, sp[9].transform.position, transform.rotation);
                enemy1.GetComponent<enemyController>().spawnerNumber = 8;
                enemy2.GetComponent<enemyController>().spawnerNumber = 9;
            }
        }
        if(!bossSpawn || wavenumber > 4)
        {
            if (counter <= 0)
            {
                int spawnPos = Random.Range(0, 8);
                
                GameObject obstacle = Instantiate(Obstacle, sp[spawnPos].transform.position, transform.rotation);
                counter = TimeBtwSpawn;
                if (shouldDecrease > 0)
                {
                    shouldDecrease--;
                }
                else
                {
                    if(TimeBtwSpawn > minTime)
                    {
                        TimeBtwSpawn -= decreaseTime;
                    }
                    if(TimeBtwSpawn < minTime)
                    {
                        TimeBtwSpawn = minTime;
                    }
                    shouldDecrease = Mathf.CeilToInt(shouldDecreaseCount/TimeBtwSpawn);
                }
            
            }
            else 
            {
                counter -= Time.deltaTime;
            }
        }
    }
}

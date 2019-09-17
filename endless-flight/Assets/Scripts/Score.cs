using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    bool count = true;
    // Update is called once per frame

    public void addScore(int amount)
    {
        if (count)
        {
            score+= amount;
        }
    }

    public void stopCounting()
    {
        count = false;
    }

}

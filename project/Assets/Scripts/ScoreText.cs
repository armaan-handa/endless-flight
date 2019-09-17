using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public Score score;
    TMPro.TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        textMesh.text = score.score.ToString();
    }
} 

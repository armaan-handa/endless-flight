using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{

    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        TMPro.TextMeshProUGUI textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        textMesh.text = score.score.ToString();
    }

}

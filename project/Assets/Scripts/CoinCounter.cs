using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    float coinsthisgame;
    TMPro.TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    private void Start()
    {
        textMesh = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        coinsthisgame = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        textMesh.text = coinsthisgame.ToString();
    }
    public void addCoin()
    {
        coinsthisgame++;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerCoinsText;

    public static int playerScore = 0;
    public static int playerCoins = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerScoreText.text = playerScore.ToString();
        playerCoinsText.text = $"x {playerCoins}";

    }
    
    
    
    
    
}

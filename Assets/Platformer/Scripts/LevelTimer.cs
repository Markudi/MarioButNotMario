using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{


    public TextMeshProUGUI textDisplay;
    public int secondsLeft = 100;
    public bool takingAway = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = secondsLeft.ToString();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(Timer());
        }
    }
    
    IEnumerator Timer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.text = secondsLeft.ToString();
        takingAway = false;
    }


}

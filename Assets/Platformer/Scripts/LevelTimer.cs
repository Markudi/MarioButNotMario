using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{


    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI timesUpTextDisplay;
    public int secondsLeft = 100;



    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = secondsLeft.ToString();
        
        StartCoroutine(Timer());
    }
    
    
    IEnumerator Timer()
    {
        if (secondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            textDisplay.text = secondsLeft.ToString();
            StartCoroutine(Timer());
        }
        else
        {
            timesUpTextDisplay.text = "Times Up! \nYou lose!";
        }
        
        
    }


}

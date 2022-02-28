using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{


    public static bool levelComplete = false;
    public string nextLevel = "Level1-2";

    public TextMeshProUGUI levelCompleteText;
    
    
    //Enter goal post    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GoalPost(Clone)" || other.gameObject.name == "GoalFlag(Clone)" && levelComplete == false)
        {
            levelComplete = true;
            StartCoroutine(levelCompleteCelebration());
        }
    }


    //Celebrate
    IEnumerator levelCompleteCelebration()
    {
        levelCompleteText.text = "THANK YOU MARIO! \n BUT OUR PRINCESS IS IN ANOTHER CASTLE!";

        levelComplete = false;

        yield return new WaitForSeconds(3);
        
        loadNextScene(nextLevel);
        
        
    }

    //Load next level
    private void loadNextScene(String nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }
}

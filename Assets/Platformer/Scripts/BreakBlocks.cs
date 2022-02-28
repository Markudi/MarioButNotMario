using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BreakBlocks : MonoBehaviour
{
   
    public float proximityThreshold = 1.8f;

    private Camera mainCamera;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        //for Mouse clicks
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Mouse click -> break blocks
        if (Input.GetMouseButtonDown(0))
        {
            MouseBreakBlocks();
        }

    }

    private void FixedUpdate()
    {
        breakBlocks();
    }



    //Raycast for mouse clicks
    private void MouseBreakBlocks()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit mouseHit))
        {
            
            if (mouseHit.transform.gameObject.name == "Question(Clone)")
            {
                ScoreManager.playerCoins++;
            }
            
            Destroy(mouseHit.transform.gameObject);
        }
    }

    //Raycast for character hit
    private void breakBlocks()
    {
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out RaycastHit hit, proximityThreshold))
        {

            //if questionMark block then add coins to player
            if (hit.transform.gameObject.name == "Question(Clone)")
            {
                ScoreManager.playerCoins++;
                ScoreManager.playerScore += 100;
            }

            if (hit.transform.gameObject.name == "Brick(Clone)")
            {
                ScoreManager.playerScore += 100;
            }

            // Debug.Log(hit.transform.name);
            Destroy(hit.transform.gameObject);
        }


    }
    
    

    private void OnCollisionEnter(Collision collision)
    {

        
    }
}

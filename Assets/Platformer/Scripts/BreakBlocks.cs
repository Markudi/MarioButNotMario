using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlocks : MonoBehaviour
{
   
    public float proximityThreshold = 1.4f;

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
            Destroy(mouseHit.transform.gameObject);
        }
    }

    //Raycast for character hit
    private void breakBlocks()
    {
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out RaycastHit hit, proximityThreshold))
        {
            Debug.DrawRay(transform.position, Vector3.up * proximityThreshold, Color.red);

            // Debug.Log(hit.transform.name);
            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.up * proximityThreshold, Color.blue);
        }
        
        
    }
    
    

    private void OnCollisionEnter(Collision collision)
    {

        
    }
}

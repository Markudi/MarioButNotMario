using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    { 
        CameraPosition();
    }


    private void CameraPosition()
    {
        //follow player
        transform.position = player.position + offset;

        
        //if player dies -> play animation and FIX UP THIS CAMERA//TODO
        
    }
    
}

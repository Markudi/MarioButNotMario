using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 10f;
    
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

        Vector3 targetPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;

    }
    
}

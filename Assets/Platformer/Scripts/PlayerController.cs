using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 20f;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    // void Update()
    // {
    //     playerMovement();
    // }

    private void FixedUpdate()
    {
        playerMovement();
    }


    private void playerMovement()
    {
        //Inputs
        float leftRight = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");
        
        
        //left-right movement
        Vector3 movement = new Vector3(leftRight, jump, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

}

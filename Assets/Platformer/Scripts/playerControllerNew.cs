using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class playerControllerNew : MonoBehaviour
{

    public float runForce = 10f;
    public float maxRunSpeed = 20f;
    public float jumpForce = 20f;
    public float jumpBonus = 4f;

    public bool feetInContactWithGround;
    
    private Rigidbody rbody;
    private Collider colliderThis;

    private Animator animComp;
    

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        colliderThis = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float castDistance = colliderThis.bounds.extents.y + 0.2f;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, castDistance);
        
        
        
        float axis = Input.GetAxis("Horizontal");
        rbody.AddForce(Vector3.right * axis * runForce, ForceMode.Force);
        

        if (!feetInContactWithGround)
        {
            animComp.SetBool("isJumping", true);
        }
        else
        {
            animComp.SetBool("isJumping", false);
        }



        if (Input.GetKeyDown(KeyCode.Space)  && feetInContactWithGround)
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (rbody.velocity.y >  0f && Input.GetKey(KeyCode.Space))
        {
            rbody.AddForce(Vector3.up * jumpBonus, ForceMode.Force);
        }

        if ( Mathf.Abs(rbody.velocity.x) > maxRunSpeed)
        {
            float newX= maxRunSpeed * Mathf.Sign(rbody.velocity.x);
            rbody.velocity = new Vector3(newX, rbody.velocity.y, rbody.velocity.z);
        }


        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = rbody.velocity.x * (1f - Time.deltaTime * 5f);
            rbody.velocity = new Vector3(newX, rbody.velocity.y, rbody.velocity.z);
        }
        
        animComp.SetFloat("Speed", rbody.velocity.magnitude);
        
    }
    
    
}

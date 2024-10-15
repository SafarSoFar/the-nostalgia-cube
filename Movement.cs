using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
   //Rigidbody rb;
    [SerializeField] float movSpeed = 5f;
    [SerializeField] Transform orientation;
    [SerializeField] AudioControl audioControl;

    Vector3 moveDir;


    
   //bool isOnGround = true;     
    void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate(){



        Move();

    }


    


    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;   
        if(moveDir != Vector3.zero){
            transform.position += moveDir * movSpeed * Time.deltaTime;
            audioControl.PlayStepSound();
        }

        /*rb.AddForce(moveDir.normalized * movSpeed * 15f, ForceMode.Force);

        Vector3 vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //ShiftPov(vel);
        if(vel.magnitude > movSpeed){
            Vector3 limitedVel = vel.normalized * movSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }*/

         
        
    }

}


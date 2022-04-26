using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimsChange : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private float verticalVelocity;
    private float gravity=14.0f;
    private float jumpForce=8.0f; 
    private float speed=1;

    // Start is called before the first frame update
    
    void Start()
    {
        anim=GetComponent <Animator> ();
        controller=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity=-gravity*Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("IsJump",true);
                verticalVelocity=jumpForce;
                
            }
            else
            {
                anim.SetBool("IsJump",false);
            }
        }
        verticalVelocity -= gravity*Time.deltaTime;
        Vector3 moveVector = new Vector3 (0,verticalVelocity,0);
        controller.Move(moveVector*Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsRun",true);
            anim.SetBool("IsIdle",false);
            Vector3 forward = transform.TransformDirection(Vector3.forward); //направление движения
            float curSpeed=speed*Input.GetAxis("Vertical");//скорость движения
            controller.SimpleMove(forward*curSpeed); //передаём скорость и направление контроллеру
        }
        else
        {
            anim.SetBool("IsRun",false);
            anim.SetBool("IsIdle",true);
        }
    }
}

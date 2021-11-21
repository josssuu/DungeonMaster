using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    private SpriteRenderer sr;
    private Animator animator;
    public float runSpeed = 40f;
    bool moving = false;
    float horizontalMove = 0f;
    bool jump = false;
    public bool facingRight = false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        moving = false;
       
        if (Math.Abs(horizontalMove) > float.Epsilon)
        {
            moving = true;
        }    
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            jump = true;
            
        }
        animator.SetBool("Walk", moving);
        animator.SetBool("IsLanding", jump);

    }
    private void FixedUpdate()
    {

        controller2D.Move(horizontalMove* Time.fixedDeltaTime,false,jump);
        jump = false;
    }
    

}

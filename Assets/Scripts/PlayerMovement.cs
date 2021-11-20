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
            sr.flipX = horizontalMove < 0f;
            moving = true;
        }    
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }
        Debug.Log(horizontalMove);
        animator.SetBool("Walk", moving);
        animator.SetBool("Jump", jump);

    }
    private void FixedUpdate()
    {

        controller2D.Move(horizontalMove* Time.fixedDeltaTime,false,jump);
        jump = false;
    }
    
}

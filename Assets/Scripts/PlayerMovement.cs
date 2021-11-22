using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    private SpriteRenderer sr;
    private Animator animator;
    private float _runSpeed = 25f;
    bool moving = false;
    float horizontalMove = 0f;
    bool jump = false;
    public bool facingRight = false;

    public float runSpeed
    {
        get => _runSpeed;
        set => _runSpeed += value;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
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
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
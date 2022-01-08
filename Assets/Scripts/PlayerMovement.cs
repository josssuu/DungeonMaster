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
    bool crouch = false;
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
            moving = true;

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            if (horizontalMove > 0.01)
                animator.SetTrigger("Slide");
            else
                animator.SetTrigger("Crouch");

            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;

        animator.SetBool("Walk", moving);
        animator.SetBool("IsLanding", jump);
    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsLanding", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
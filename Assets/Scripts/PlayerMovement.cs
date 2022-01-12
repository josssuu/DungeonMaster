using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    private SpriteRenderer sr;
    private Animator animator;
    private AudioSource audioSource;
    private float _runSpeed = 25f;
    bool moving = false;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool facingRight = false;
    bool onGround = true;

    public float runSpeed
    {
        get => _runSpeed;
        set => _runSpeed += value;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        moving = false;

        if (Math.Abs(horizontalMove) > float.Epsilon)
            moving = true;

        if (moving && !audioSource.isPlaying && !jump && onGround && !crouch) audioSource.Play();
        if (!moving) audioSource.Stop();

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            audioSource.Stop();
            SoundManager.PlaySound("jumpland");
            onGround = false;
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsLanding", true);
            jump = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            if (horizontalMove > 0.01)
            {
                animator.SetTrigger("Slide");
                audioSource.Stop();
                SoundManager.PlaySound("slide");
            }
            else
            {
                animator.SetTrigger("Crouch");
                audioSource.Stop();
            }

            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;

        animator.SetBool("Walk", moving);
    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsLanding", true);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "5d403c2b-411a-499d-9a9a-10778dd0cfd9_scaled_1")
        {
            onGround = true;
        }
    }
}
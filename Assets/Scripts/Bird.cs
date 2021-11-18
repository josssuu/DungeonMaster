using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float forceAmount = 100;

    Rigidbody2D rigidBody2D;
    AudioSource audioSource;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody2D.simulated = true;
            rigidBody2D.velocity = Vector2.zero;
            rigidBody2D.AddForce(new Vector2(0, forceAmount));
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidBody2D.simulated = true;
            rigidBody2D.velocity = Vector2.zero;
            rigidBody2D.AddForce(new Vector2(forceAmount, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidBody2D.simulated = true;
            rigidBody2D.velocity = Vector2.zero;
            rigidBody2D.AddForce(new Vector2(-forceAmount, 0));
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        //Restart();
    }
    

    public void Restart()
    {
        rigidBody2D.rotation = 0f;
        rigidBody2D.velocity = Vector2.zero;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Game.Instance.Restart();
    }

    private void OnBecameInvisible()
    {
        Restart();
    }
}
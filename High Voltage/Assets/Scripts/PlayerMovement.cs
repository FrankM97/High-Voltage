using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;

    public float maxSpeed = 100;

	private bool onGround;

	public AudioSource audioSource;

	public SpriteRenderer spriteRenderer;

	int jumpCount;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");

		//GetAnimatorComponent<Animator>(maxSpeed);

		if (onGround == true && move!= 0)
		{
			audioSource.Play();
		}
        else
		{
			audioSource.Pause();
		}

        rb.velocity = new Vector2 (speed * move, rb.velocity.y);

		if (move > 0)
		{
			spriteRenderer.flipX = false;
		}
		else if( move < 0)
		{
			spriteRenderer.flipX = true;
		}

		if (jumpCount < 1)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rb.AddForce(transform.up * speed * 35);

				jumpCount += 1;
			}
		}
    }

	private void OnCollisionEnter2D(Collision2D collider)
	{
		Debug.Log("Collision Detected");
		onGround = true;
		jumpCount = 0;
	}

	private void OnCollisionExit2D(Collision2D collider)
	{
		Debug.Log("Collision Detected");
		onGround = false;
        
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public new Camera camera;
	public new Rigidbody2D rigidbody;
	private Vector2 movement;
	private Vector3 mousePosition;

	public float moveSpeed;

	public float dashSpeed;
	private float dashDuration;
	private float dashCooldown;

	public bool isDashing = false;
	private Vector2 dashDirection;

	private bool facingRight = true;

	public Animator playerAnimator;
	public SpriteRenderer playerSprite;


	private void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

    private void Update()
    {
		mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

		movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

		if (mousePosition.x < rigidbody.transform.position.x && facingRight)
		{
			Flip();
		}

		else if (mousePosition.x > rigidbody.transform.position.x && !facingRight) 
		{;
			Flip();
		}

		if (dashCooldown > 0) 
		{
			dashCooldown -= Time.deltaTime;
		}
		else if (dashCooldown <= 0) 
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				dashDirection = (mousePosition - rigidbody.transform.position);

				dashDirection.Normalize();

				isDashing = true;
				dashCooldown = 2f;
				dashDuration = 0.3f;
			}
		}
		if (isDashing) 
		{
			dashDuration -= Time.deltaTime;
			if (dashDuration <= 0) 
			{
				playerAnimator.SetBool("isDashing", false);
				isDashing = false;
			}
		}
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = moveSpeed * Time.deltaTime * movement;

		if (movement != Vector2.zero)
		{
			playerAnimator.SetBool("isRunning", true);
		}
		else 
		{
			playerAnimator.SetBool("isRunning", false);
		}

		if (isDashing) 
		{
			rigidbody.velocity = dashDirection * dashSpeed;
			playerAnimator.SetBool("isDashing", true);
		}
	}
	private void Flip() 
	{
		playerSprite.flipX = !playerSprite.flipX;
		facingRight = !facingRight;
	}

}

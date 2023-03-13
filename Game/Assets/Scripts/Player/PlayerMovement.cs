using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	public new Camera camera;
	public new Rigidbody2D rigidbody;
	private Vector2 movement;
	private SpriteRenderer sprite;
	private Vector3 mousePosition;


	[Header("Running")]
	public float moveSpeed;


	[Header("Dashing")]
	public float dashSpeed;
	private float dashDuration;
	private float dashCooldown;

	public bool isDashing = false;
	private Vector2 dashDirection;

	[Header("Animation")]
	private GameObject gameobject;
	private bool facingRight = true;
	public Animator animator;



	private void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

		sprite = GetComponent<SpriteRenderer>();

		gameobject = GetComponent<GameObject>();
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
		{
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
				dashDirection = (mousePosition - rigidbody.transform.position).normalized;

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
				isDashing = false;
				animator.SetBool("isDashing", false);
			}
		}
	}

	private void FixedUpdate()
	{
		rigidbody.velocity = moveSpeed * Time.deltaTime * movement;

		if (movement != Vector2.zero)
		{
			animator.SetBool("isMoving", true);
		}
		else 
		{
			animator.SetBool("isMoving", false);
		}

		if (isDashing) 
		{
			rigidbody.velocity = dashDirection * dashSpeed;
			animator.SetBool("isDashing", true);
		}
	}
	private void Flip() 
	{
		sprite.flipX = !sprite.flipX;
		facingRight = !facingRight;
	}

}

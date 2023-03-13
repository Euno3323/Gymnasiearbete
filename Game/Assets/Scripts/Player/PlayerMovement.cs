using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	public new Camera camera;
	private Vector2 movement;
	private new Rigidbody2D rigidbody;
	private SpriteRenderer sprite;


	[Header("Running")]
	public float moveSpeed;


	[Header("Dashing")]
	public float dashDistance;
	private float dashCooldown;
	public bool canDash;
	public bool isDashing;
	private Vector3 mousePosition;
	private Vector3 dashDirection;

	[Header("Animation")]
	private GameObject gameobject;
	private bool facingRight = true;
	public Animator animator;



	private void Start()
    {
		isDashing = false;
		canDash = true;
		dashCooldown = 0;


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

		if (dashCooldown <= 0)
		{
			dashCooldown = 0;
			canDash = true;
		}
		dashCooldown -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.Space) && canDash) 
		{
			dashDirection = new Vector3(mousePosition.x - rigidbody.transform.position.x, mousePosition.y - rigidbody.transform.position.y, 0).normalized;
			isDashing = true;
		}
	}



	private void FixedUpdate()
	{
		if (isDashing == true) 
		{
			Dash();
		}

		rigidbody.velocity = moveSpeed * Time.deltaTime * movement;

		if (movement != Vector2.zero)
		{
			animator.SetBool("isMoving", true);
		}
		else 
		{
			animator.SetBool("isMoving", false);
		}
	}



	private void Flip() 
	{
		sprite.flipX = !sprite.flipX;
		facingRight = !facingRight;
	}

	private void Dash() 
	{
		rigidbody.transform.position = rigidbody.transform.position + dashDirection * dashDistance;
		dashCooldown = 5;
		isDashing = false;
		canDash = false;
	}
}

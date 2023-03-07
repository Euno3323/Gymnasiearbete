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


	[Header("Running")]
    public float moveSpeed;


	[Header("Dashing")]
	public float dashDistance;
	private float dashCooldown;
	public bool canDash;
	public bool isDashing;
	private Vector3 mousePosition;
	private Vector3 dashDirection;



	private void Start()
    {
		isDashing = false;
		canDash = true;
		dashCooldown = 0;


		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}



    private void Update()
    {
		if (dashCooldown <= 0)
		{
			dashCooldown = 0;
			canDash = true;
		}
		dashCooldown -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.Space) && canDash) 
		{
			mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
			dashDirection = new Vector3(mousePosition.x - rigidbody.transform.position.x, mousePosition.y - rigidbody.transform.position.y, 0).normalized;
			isDashing = true;
		}
		movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}



	private void FixedUpdate()
	{
		if (isDashing == true) 
		{
			rigidbody.transform.position = rigidbody.transform.position + dashDirection * dashDistance;
			dashCooldown = 5;
			isDashing = false;
			canDash = false;
		}
		rigidbody.velocity = moveSpeed * Time.deltaTime * movement;
	}
}

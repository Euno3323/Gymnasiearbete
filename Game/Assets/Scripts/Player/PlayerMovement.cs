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
	private new Rigidbody2D rigidbody;
	private Vector2 movement;


	[Header("Running")]
    public float moveSpeed;


	[Header("Dashing")]
	public float dashDistance;
	public bool canDash;
	private float dashCooldown;
	private bool isDashing;
	private Vector3 mousePosition;
	private Vector3 dashDirection;
	private Vector3 dashTarget;


	void Start()
    {
		isDashing = false;
		canDash = true;
		dashCooldown = 0;
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}


    void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
		dashDirection = new Vector3(mousePosition.x - rigidbody.transform.position.x, mousePosition.y - rigidbody.transform.position.y, 0).normalized;
		dashTarget = rigidbody.transform.position + dashDirection * dashDistance;

		if (dashCooldown <= 0) 
		{
			dashCooldown = 0;
			canDash = true;
		}
		dashCooldown -= Time.deltaTime;

		if (Input.GetKey(KeyCode.Space) && canDash) 
		{
			isDashing = true;
		}
		movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}
	 void FixedUpdate()
	{
		if (isDashing == true) 
		{
			rigidbody.transform.position = dashTarget;
			dashCooldown = 5;
			isDashing = false;
			canDash = false;
		}
		rigidbody.velocity = moveSpeed * Time.deltaTime * movement;
	}
}

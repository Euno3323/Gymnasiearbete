using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Camera cam;
	private Rigidbody2D rigidbody;
	private Vector2 movement;


	[Header("Running")]
    public float runningSpeed;


	[Header("Dashing")]
	public float dashingPower;
    private float dashingCooldown = 5f;
    private float dashingTimer = 5f;
    public bool isDashing;

	void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
		isDashing = false;
	}


    
    void Update()
    {
        dashingTimer += Time.deltaTime;

		if (dashingTimer >= dashingCooldown)
		{
			dashingTimer = dashingCooldown;
			isDashing = false;
		}

		if (!isDashing)
        {
            if (Input.GetKey("space"))
            {
				isDashing = true;

				dashingTimer = 0;

				Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

                Vector3 direction = (mousePos - rigidbody.transform.position);

                direction.z = 0;

				rigidbody.AddForce(direction * dashingPower);
			}
        }
	}


	

	void FixedUpdate()
    {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		movement = new Vector3(x, y, 0);
		rigidbody.MovePosition(rigidbody.position + movement * runningSpeed * Time.deltaTime);
	}
}

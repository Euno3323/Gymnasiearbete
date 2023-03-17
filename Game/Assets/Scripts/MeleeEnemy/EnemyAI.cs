using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	[SerializeField]
	public Transform player;
	public Transform armPivot;
	private Rigidbody2D rb;

	[SerializeField]
	private int chaseDistanceThreshold = 10, attackDistanceThreshold = 2;

	[SerializeField]
	public float attackDelay;
	private float passedTime;

	[SerializeField]
	private float maxSpeed = 2;

	[SerializeField]
	private bool facingRight = true;
	public SpriteRenderer sprite;
	public Animator animator;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		passedTime = attackDelay;
	}

	private void Update()
	{
		if (player == null)
		{
			return;
		}

		float distance = Vector2.Distance(player.position, transform.position);
		if (distance < chaseDistanceThreshold)
		{
			if (distance < attackDistanceThreshold)
			{
				animator.SetBool("isRunning", false);
				if (passedTime >= attackDelay)
				{
					passedTime = 0;
					GetComponent<MeleeEnemyAttack>().Attack();
				}
			}
			else
			{
				animator.SetBool("isRunning", true);
				Vector2 direction = player.position - transform.position;
				direction.Normalize();
				rb.velocity = direction * maxSpeed;
			}
		}
		else
		{
			animator.SetBool("isRunning", false);
			return;
		}

		if (passedTime < attackDelay)
		{
			passedTime += Time.deltaTime;
		}
		if (player.position.x < transform.position.x && facingRight)
		{
			Flip();
		}
		else if (player.position.x > transform.position.x && !facingRight)
		{
			Flip();
		}
		armPivotRotation();
	}

	private void armPivotRotation()
	{
		Vector3 difference = player.position - transform.position;

		difference.Normalize();

		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		armPivot.rotation = Quaternion.Euler(0f, 0f, rotation);

		if (rotation < -90 || rotation > 90)
		{
			armPivot.rotation = Quaternion.Euler(180f, 0f, -rotation);
		}
	}

	private void Flip() 
	{
		sprite.flipX = !sprite.flipX;
		facingRight = !facingRight;
	}
}

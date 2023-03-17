using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RangedEnemyAi : MonoBehaviour
{
	[SerializeField]
	public Transform player;
	public Transform armPivot;
	private Rigidbody2D rb;

	[SerializeField]
	private int chaseDistanceThreshold = 10, attackDistanceThreshold = 4, runawayDistanceThreshold = 3;

	[SerializeField]
	private float attackCooldown = 3f;
	private float passedTime = 0.5f;

	[SerializeField]
	private float maxSpeed = 2;

	private bool facingRight = true;
	public SpriteRenderer sprite;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (player == null)
		{
			return;
		}
		if (passedTime < attackCooldown)
		{
			passedTime += Time.deltaTime;
			Debug.Log(passedTime + attackCooldown);
		}
		float distance = Vector2.Distance(player.position, transform.position);
		if (distance < chaseDistanceThreshold)
		{
			if (distance < attackDistanceThreshold)
			{
				if (distance < runawayDistanceThreshold && passedTime > attackCooldown)
				{
					//&& passedTime > attackCooldown
					Vector2 direction = player.position - transform.position;
					direction.Normalize();
					rb.velocity = direction * -maxSpeed;

					
					gameObject.GetComponent<RangedEnemyAttack>().Attack();
					passedTime = 0;	
				}
				else if (passedTime > attackCooldown)
				{
					gameObject.GetComponent<RangedEnemyAttack>().Attack();
					passedTime = 0;
				}
			}
			else 
			{
				Vector2 direction = player.position - transform.position;
				direction.Normalize();
				rb.velocity = direction * maxSpeed;
			}
		}
		else 
		{
			return;
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

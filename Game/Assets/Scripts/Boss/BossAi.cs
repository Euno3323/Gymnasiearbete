using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
	[SerializeField]
    public bool isTriggered = false;
	public Transform player;
	private Rigidbody2D rb;

	[SerializeField]
	public SpriteRenderer sprite;
	public Animator spriteAnimator;
	private bool facingRight = true;

	[SerializeField]
	private int attackDistanceThreshold = 2;

	[SerializeField]
	private float maxSpeed = 3f;

	[SerializeField]
	private float attackDelay = 5f;
	private float passedTime;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		passedTime = attackDelay;
	}

	public void Update()
	{
		if (isTriggered) 
		{
			if (player == null)
			{
				return;
			}
			float distance = Vector2.Distance(player.position, transform.position);
			if (distance < attackDistanceThreshold)
			{
				spriteAnimator.SetBool("isRunning", false);
				if (passedTime >= attackDelay)
				{
					StartCoroutine(AttackWithDelay());
				}
			}
			else 
			{
				spriteAnimator.SetBool("isRunning", true);
				Vector2 direction = player.position - transform.position;
				direction.Normalize();
				rb.velocity = direction * maxSpeed;
			}
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
	}

	private void Flip()
	{
		sprite.flipX = !sprite.flipX;
		facingRight = !facingRight;
	}

	IEnumerator AttackWithDelay() 
	{
		spriteAnimator.SetTrigger("isAttacking");
		passedTime = 0;
		yield return new WaitForSeconds(0.8f);
		GetComponent<IAttackInterface>().Attack();
		yield return null;
	}
}

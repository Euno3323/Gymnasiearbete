using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour, IStatInterface
{
	private enum State
	{
		Idle,
		Chasing,
		Attacking,
	}
	private State state;

	public Transform player;
	public float moveSpeed;
	public float targetRange;
	public bool awarness = false;

	public Transform armPivot;

	public float attackRange;
	public int attackDamage;
	public float attackCooldown;
	private bool canAttack = true;

	public LayerMask playerLayer;
	public Transform attackPoint;
	public Animator swordAnimator;

	public int maxHealth;
	private int currentHealth;

	public bool facingRight = true;
	public SpriteRenderer sprite;
	public Animator animator;


	private void Start() 
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (Vector2.Distance(transform.position, player.position) <= targetRange)
		{
			awarness = true;
			if (player.position.x < transform.position.x && facingRight)
			{
				Flip();
			}
			else if (player.position.x > transform.position.x && !facingRight) 
			{
				Flip();
			}
		}
		else 
		{
			animator.SetBool("isRunning", false);
			awarness = false;
		}
		if (Vector2.Distance(transform.position, player.position) <= attackRange && canAttack) 
		{
			Attack(attackDamage);
			canAttack = false;
		}
	}

	private void FixedUpdate()
	{
		if (awarness) 
		{
			animator.SetBool("isRunning", true);
			transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
			armPivotRotation();
		}
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

	public void Die() 
	{
		Debug.Log("Enemy Died");
		this.enabled = false;
		GetComponent<Collider2D>().enabled = false;
	}

	public void Attack(int attackDamage) 
	{
		swordAnimator.SetTrigger("isAttacking");

		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

		foreach (Collider2D player in hitPlayer)
		{
			player.GetComponent<PlayerAttackAndHealth>().takeDamage(attackDamage);
		}
	}

	public void takeDamage(int damage) 
	{
		Debug.Log("Enemy took damage");
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Die();
		}
	}
}

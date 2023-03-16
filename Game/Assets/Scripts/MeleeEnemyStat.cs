using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStat : MonoBehaviour, IStatInterface
{
	[SerializeField]
	public LayerMask playerLayer;
	public Transform attackPoint;

	[SerializeField]
	public float attackRange;

	[SerializeField]
	public int maxHealth;
	private int currentHealth;

	[SerializeField]
	public Animator swordAnimator;


	void Start()
	{
		currentHealth = maxHealth;
	}

	public void Die()
	{
		Destroy(gameObject);
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
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}


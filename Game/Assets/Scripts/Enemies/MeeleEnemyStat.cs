using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemyStat : MonoBehaviour, IStatInterface
{
	public int maxHealth;
	private int currentHealth;

	public int attackDamage;
	public float attackRange;
	public Transform attackPoint;
	public LayerMask playerLayer;

	private void Start() 
	{
		currentHealth = maxHealth;
	}

	public void Die() 
	{ 
		Destroy(gameObject);
	}

	public void Attack() 
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<PlayerStat>().takeDamage(attackDamage);
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

}

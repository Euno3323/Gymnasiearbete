using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyHealth : MonoBehaviour, IHealthInterface
{
	[SerializeField]
	private int maxHealth = 3;
	private int currentHealth;

	private void Awake()
	{
		currentHealth = maxHealth;
	}
	public void Die()
	{
		Destroy(gameObject);
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
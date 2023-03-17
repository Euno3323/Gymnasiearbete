using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IHealthInterface
{
    [SerializeField]
	public int maxHealth = 20;
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

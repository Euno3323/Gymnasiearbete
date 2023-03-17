using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyHealth : MonoBehaviour, IHealthInterface
{
    [SerializeField]
    private int maxHealth = 2;
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

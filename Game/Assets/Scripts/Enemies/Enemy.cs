using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStatInterface
{
	public int maxHealth;
	private int currentHealth;

	public int attackDamage;

	public Animator animator;
	void Start() 
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
	}

	public void Die()
	{
		Debug.Log("ENEMY DEAD");
	}

	public void Attack() 
	{
		Debug.Log("ENEMY ATTACKED");
	}

	public void takeDamage(int damage) 
	{
		currentHealth -= damage;

		Debug.Log($"Enemy took {damage} damage");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

}

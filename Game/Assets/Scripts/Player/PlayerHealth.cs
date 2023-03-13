using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public int maxHealth = 3;
    public int currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
		if (currentHealth <= 0) 
		{
			die();
		}
	}

	public void takeDamage() 
	{
		currentHealth -= 1;
	}

	public void die() 
	{ 
		Destroy(gameObject);
	}
}

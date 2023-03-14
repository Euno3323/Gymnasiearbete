using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
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
		Debug.Log("Enemy died");
	}
}

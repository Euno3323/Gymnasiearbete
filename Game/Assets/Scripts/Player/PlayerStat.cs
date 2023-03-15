using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour, IStatInterface
{
    private int maxHealth = 4;
    private int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int attackDamage;
    public float attackRange;

    public Animator swordAnimator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

	private void Start()
	{
        currentHealth = maxHealth;
	}

	private void Update()
	{
        if (Input.GetMouseButtonDown(0)) 
        {
			swordAnimator.SetTrigger("isAttacking");
			Attack();
		}

        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            { 
                hearts[i].sprite = emptyHeart;
            }
        }
	}

    public void Die() 
    {
        Debug.Log("Player died");
    }

    public void Attack() 
    {
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<MeeleEnemyStat>().takeDamage(attackDamage);
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
	public void takeDamage(int damage) 
    {
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			Die();
		}
	}
}

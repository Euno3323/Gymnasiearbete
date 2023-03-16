using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour, IStatInterface
{
    public LayerMask playerLayer;
    public Transform attackPoint;
    public Animator swordAnimator;

	public float attackRange;
	public float attackDamage;
    public float attackCooldown;
    public bool canAttack = true;

	public int maxHealth;
    private int currentHealth;


    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Die() 
    {
        Debug.Log("Enemy Died");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
     }

    public void Attack(int attackDamage) 
    { 
    
    }

    public void takeDamage(int damage) 
    {
        Debug.Log("Take Damage");
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackAndHealth : MonoBehaviour, IStatInterface
{
	[SerializeField]
	public GameObject gameOverPanel;
	public LayerMask enemyLayer;
	public Transform attackPoint;

	[SerializeField]
	private float attackRange = 1f;
	private int attackDamage = 1;
	private float attackCooldown = 1f;
	private float passedTime = 1f;

	[SerializeField]
	private int maxHealth = 4;
	private int currentHealth;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	[SerializeField]
	public Animator swordAnimator;


	public void Start()
	{
		currentHealth = maxHealth;
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (passedTime >= attackCooldown) 
			{
				Attack(attackDamage);
				passedTime = 0;
			}
		}
		if (passedTime < attackCooldown) 
		{
			passedTime += Time.deltaTime;
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
		if (Input.GetKeyDown(KeyCode.L)) 
		{
			takeDamage(1);
		}
	}
	public void Die()
	{
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;
	}

	public void Attack(int attackDamage)
	{
		swordAnimator.SetTrigger("isAttacking");

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<MeleeEnemyStat>().takeDamage(attackDamage);
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


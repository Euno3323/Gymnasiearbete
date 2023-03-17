using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackInterface
{
	public LayerMask enemyLayer;
	public Transform attackPoint;

	public Animator swordAnimator;

	[SerializeField]
	private float attackRange = 1f;
	private int attackDamage = 1;
	private float attackCooldown = 0.5f;
	private float passedTime = 0.5f;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (passedTime >= attackCooldown)
			{
				Attack();
				passedTime = 0;
			}
		}
		if (passedTime < attackCooldown)
		{
			passedTime += Time.deltaTime;
		}
	}

	public void Attack()
	{
		swordAnimator.SetTrigger("isAttacking");

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<IHealthInterface>().takeDamage(attackDamage);
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
}


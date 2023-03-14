using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public Animator swordAnimator;
	public Transform attackPoint;
	public float attackRange;
	public LayerMask enemyLayer;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			swordAnimator.SetTrigger("isAttacking");
			Attack();
		}
	}

	void Attack()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		foreach (Collider2D enemy in hitEnemies) 
		{
			enemy.GetComponent<Enemy>().takeDamage();
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

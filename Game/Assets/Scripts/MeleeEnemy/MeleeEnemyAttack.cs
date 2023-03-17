using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour, IAttackInterface
{
	public LayerMask playerLayer;
	public Transform attackPoint;
	public Animator swordAnimator;

	[SerializeField]
	private int attackDamage = 1;
	private float attackRange = 0.8f;
	public void Attack()
	{
		swordAnimator.SetTrigger("isAttacking");

		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

		foreach (Collider2D player in hitPlayer)
		{
			player.GetComponent<PlayerHealth>().takeDamage(attackDamage);
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


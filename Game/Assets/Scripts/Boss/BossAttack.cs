using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour, IAttackInterface
{
    public LayerMask playerLayer;
    public Transform attackPoint;
    public Animator animator;
    
    [SerializeField]
    public int attackDamage = 5;
    public float attackRange = 1;
    public void Attack() {
        animator.SetTrigger("isAttacking");

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
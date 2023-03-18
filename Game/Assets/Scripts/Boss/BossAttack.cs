using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour, IAttackInterface
{
    public LayerMask playerLayer;
    public Animator animator;

	[SerializeField]
	private int attackDamage = 2;

	[SerializeField]
	private float attackRange = 2;
    public void Attack() {
        //animator.SetTrigger("isAttacking");

		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);

		foreach (Collider2D player in hitPlayer)
		{
			player.GetComponent<PlayerHealth>().takeDamage(attackDamage);
		}
    }
    void OnDrawGizmosSelected()
	{
		if (transform.position == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
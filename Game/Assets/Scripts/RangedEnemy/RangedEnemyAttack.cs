using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour, IAttackInterface
{
	public GameObject arrow;
	public Transform player;
	public LayerMask playerLayer;
	public Transform attackPoint;

	[SerializeField]
	private int attackDamage = 1;
	
	public void Attack() 
	{
		Instantiate(arrow, attackPoint.position, Quaternion.identity);

		/* 		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, 1f, playerLayer);

		if (transform.position.x == player.position.x && transform.position.y == player.position.y)
		{
			Destroy(gameObject);
		}



		void OnTriggerEnter2D(Collider2D player)
		{
			player.GetComponent<PlayerHealth>().takeDamage(1);
			Destroy(gameObject);
		}
		*/
	}
}

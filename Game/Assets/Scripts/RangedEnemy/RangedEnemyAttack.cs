using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour, IAttackInterface
{
	[SerializeField]
	public GameObject arrow_prefab;
	public Transform attackPoint;
	public GameObject player;
	public void Attack() 
	{ 
		GameObject Arrow = Instantiate(arrow_prefab, attackPoint.position, attackPoint.rotation);
		
		Vector2 direction = player.transform.position - attackPoint.position;
		direction.Normalize();
		Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
		rb.velocity = direction * 7.5f; 
		
		Destroy(Arrow, 5);
	}
}

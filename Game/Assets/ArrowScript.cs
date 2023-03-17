using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
	private float maxSpeed = 3f;
	public Transform player;
	private Vector2 target;

	private void Awake()
	{
		target = new Vector2(player.position.x, player.position.y);
	}
	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, maxSpeed * Time.deltaTime);
	}
}

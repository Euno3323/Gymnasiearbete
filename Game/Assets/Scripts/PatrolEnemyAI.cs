using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolEnemyAI : MonoBehaviour
{
	private enum State
	{
		Roaming,
		ChaseTarget,
		Attack,
	}
	private State state;

	public float speed;

	public float waitTime;
	public float roamRange;
	private Vector2 startingPos;
	private Vector2 roamingTargetPos;
	private bool canPatrol;

	public float targetRange;
	public float attackRange;
	public Transform target;

	public Transform armPivot;
	public Rigidbody2D rb;

	private void Start() 
	{
		state = State.Roaming;
		startingPos = transform.position;
		roamingTargetPos = ChooseNewTargetPos();
		canPatrol = true;
	}

	private void Update()
	{
		switch (state) 
		{
			default:
			case State.Roaming:
				if (canPatrol)
				{
					transform.position = Vector2.MoveTowards(transform.position, roamingTargetPos, speed * Time.deltaTime);
					if ((Vector2)transform.position == roamingTargetPos)
					{
						StartCoroutine(Wait());
						canPatrol = false;
					}
				}
				findTarget();
				break;
			case State.ChaseTarget:
				transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				armPivotRotation();
				
				break;
			case State.Attack:
				break;
		}
	}


	private Vector2 ChooseNewTargetPos() 
	{
		return startingPos + Random.insideUnitCircle * roamRange;
	}

	IEnumerator Wait() 
	{
		yield return new WaitForSeconds(waitTime);
		roamingTargetPos = ChooseNewTargetPos();
		canPatrol = true;
	}

	private void findTarget()
	{
		if (Vector3.Distance(transform.position, target.position) < targetRange) 
		{
			state = State.ChaseTarget;
		}
	}

	private void armPivotRotation() 
	{
		Vector3 difference = target.position - transform.position;

		difference.Normalize();

		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		armPivot.rotation = Quaternion.Euler(0f, 0f, rotation);
	}

	private void findAttackRange() 
	{
		if (Vector3.Distance(transform.position, target.position) < attackRange) 
		{
			state = State.Attack;
		}
	}
}

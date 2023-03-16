using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IStatInterface
{
	public void Die();

	public void Attack(int attackDamage);

	public void takeDamage(int damage);
}

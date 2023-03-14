using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatInterface 
{
    void Attack();

    void takeDamage(int damage);

    void Die();
}

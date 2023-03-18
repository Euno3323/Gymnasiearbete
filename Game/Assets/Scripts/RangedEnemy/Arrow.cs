using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerHealth>() != null) {
            other.gameObject.GetComponent<IHealthInterface>().takeDamage(1);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TimeToLive = 20f;
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}

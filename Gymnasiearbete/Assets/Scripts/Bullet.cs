using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TimeToLive = 20f;
    public GameObject hitEffect;
    public Sprite[] sprites;
    private int rand;

    void Start()
    {
        //rand = Random.Range(0, sprites.Length);
        //gameObject.GetComponent<SpriteRenderer>().sprite = sprites[rand];
        Destroy(gameObject, TimeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AIHealth>() != null)
        {
            collision.gameObject.GetComponent<AIHealth>().TakeDamage(10);
        }
        //GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;
    public float postattackspeed = 0.5f;
    public float dmg = 10f;
    private float distance;
    private float last_attack;
    private bool chasing;


    // Start is called before the first frame update
    void Start()
    {
        last_attack = Time.time;
        chasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if ((distance < 4 || chasing) && (Time.time-last_attack > 2f))
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);   
            chasing = true;
        } else if (chasing)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, postattackspeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        if (distance > 10)
        {
            chasing = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() == null)
        {
            return;
        }
        last_attack = Time.time;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, 0 * 4 );
        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmg);
    }
}

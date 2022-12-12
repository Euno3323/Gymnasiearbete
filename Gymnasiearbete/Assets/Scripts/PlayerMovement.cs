using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Gåhastighet
    public float walkingSpeed = 5f;
    //Springhastiget
    public float runningSpeed = 7.5f;
    //Sann om spelaren springer, falsk om han går
    private bool run;
    //objektet som skriptet ska påverka/röra
    public Rigidbody2D rb;
    public GameObject firePoint;
    //Rörelseförändringar
    Vector2 movement;
    Vector2 mousePos;

    //Variabel för spriten
    public SpriteRenderer spriteRender;
    
    //Startkonditioner
    void Start()
    {
        run = false;
        spriteRender = GetComponent<SpriteRenderer>();
	}
    //Uppdaterar på varje nya bild
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Run"))
        {
            run = true; 
        }
        else 
        {  
            run = false;
        }

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


		//postitionen av musen i jämförelse med spelaren
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //Flippa spriten på karaktären
        if (rotZ < 89 && rotZ > -89)
        {
            spriteRender.flipX = false;
        }
        else 
        {
            spriteRender.flipX = true;
        }
	}
    //Konstant uppdatering
    void FixedUpdate()
    {
        //Rörelse
        if (run)
        {
            rb.MovePosition(rb.position + movement * runningSpeed * Time.fixedDeltaTime);
        } 
        else
        {
            rb.MovePosition(rb.position + movement * walkingSpeed * Time.fixedDeltaTime);
        }
        Vector2 firePointPos = new Vector2(firePoint.transform.position.x, firePoint.transform.position.y);
        Vector3 lookDir = mousePos - firePointPos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x);
        firePoint.transform.localPosition = new Vector2(Mathf.Cos(angle) * 0.6f, Mathf.Sin(angle) * 0.6f);
        angle = angle * Mathf.Rad2Deg - 90f;
        firePoint.transform.eulerAngles = Vector3.forward * angle;
	}
}

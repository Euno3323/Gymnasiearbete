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
    //används för kamerans position
    public Camera cam;
    //Rörelseförändringar
    Vector2 movement;
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

        //postitionen av musen
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //Flip spriten på karaktären
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
	}
}

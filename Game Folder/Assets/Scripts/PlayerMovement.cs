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
    //spelarrotation
    Vector2 mousePos;
    
    //Startkonditioner
    void Start()
    {
        run = false;
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

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}

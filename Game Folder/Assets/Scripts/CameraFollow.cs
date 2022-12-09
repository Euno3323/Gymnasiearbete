using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variabel för hur snabbt kameran följer efter
    public float FollowSpeed = 2f;
    
    //Variabel för att välja det objekt som kameran ska följa efter
    public Transform target;

    void Update() 
    {
		//Vi tar positionen av objektet i target
		Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        //Vi ger kameran positionen av objektet
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

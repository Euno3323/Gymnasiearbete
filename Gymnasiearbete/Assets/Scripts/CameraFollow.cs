using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variabel f�r hur snabbt kameran f�ljer efter
    public float FollowSpeed = 2f;
    
    //Variabel f�r att v�lja det objekt som kameran ska f�lja efter
    public Transform target;

    void Update() 
    {
		//Vi tar positionen av objektet i target
		Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        //Vi ger kameran positionen av objektet
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

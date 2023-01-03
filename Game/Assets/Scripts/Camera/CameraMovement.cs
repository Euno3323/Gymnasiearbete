using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed;
    public Transform target;
    private Vector3 newPos;

    void Update()
    {
        newPos = new Vector3(target.position.x, target.position.y, -10f);
    }
    void FixedUpdate()
    {
		transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
	}
}

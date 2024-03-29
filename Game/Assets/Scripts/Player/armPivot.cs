using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armPivot : MonoBehaviour
{
	private void FixedUpdate()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		difference.Normalize();

		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0f, 0f, rotation);

		if (rotation < -90 || rotation > 90)
		{
			transform.localRotation = Quaternion.Euler(180f, 0f, -rotation);
		}
	}
}

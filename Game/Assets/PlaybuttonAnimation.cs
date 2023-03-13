using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybuttonAnimation : MonoBehaviour
{
    public Animator animator;

	private void OnMouseOver()
	{
		animator.SetBool("isHighlighted", true);

		if (Input.GetMouseButtonDown(0)) 
		{
			animator.SetBool("isPressed", true);
		}
		
	}

	private void OnMouseExit()
	{
		animator.SetBool("isHighlighted", false);
	}
}

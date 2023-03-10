using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
	public Animator animator;

	private void OnMouseOver()
	{
		animator.SetBool("isHighlighted", true);

		if (Input.GetMouseButtonDown(0))
		{
			animator.SetBool("isPressed", true);
			StartCoroutine(buttonPressTimer());
		}

	}

	private void OnMouseExit()
	{
		animator.SetBool("isHighlighted", false);
	}

	private IEnumerator buttonPressTimer() 
	{
		yield return new WaitForSeconds(1f);
		animator.SetBool("isPressed", false);
	}
}

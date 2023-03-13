using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
	public GameObject OptionsMenuUI;
	public Animator animator;

	public void Close() 
	{
		OptionsMenuUI.SetActive(false);
	}
}

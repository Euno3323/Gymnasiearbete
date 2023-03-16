using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public GameObject OptionsMenuUI;

	public void Play()
	{
		StartCoroutine(WaitPlay());
	}

	public void Exit()
	{
		StartCoroutine(WaitExit());
	}

	IEnumerator WaitPlay() 
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Main");
	}

	IEnumerator WaitExit()
	{
		yield return new WaitForSeconds(1f);
		Application.Quit();
	}
}

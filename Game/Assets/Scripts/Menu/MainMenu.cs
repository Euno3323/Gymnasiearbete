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
		SceneManager.LoadScene("Main");
	}

	public void Options()
	{
		OptionsMenuUI.SetActive(true);
	}

	public void Exit()
	{
		Debug.Log("Exit");
		Application.Quit();
	}
}

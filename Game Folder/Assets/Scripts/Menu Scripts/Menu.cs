using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() 
    {
		StartCoroutine(PlayDelay());
		IEnumerator PlayDelay()
		{
			yield return new WaitForSeconds(1f);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void QuitGame() 
	{
		StartCoroutine(QuitDelay());
		IEnumerator QuitDelay()
		{
			yield return new WaitForSeconds(1f);
			Application.Quit();
		}
	}
}

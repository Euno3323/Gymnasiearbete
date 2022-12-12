using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public bool isInRange;

    public KeyCode interactKey;

    void Update()
    {
        if (isInRange) //Kollar om man �r range
        {
            if (Input.GetKeyDown(interactKey)) //Spelaren ska klicka p� knappen
            {
				SceneManager.LoadScene(2); //Loadar n�sta scen
			}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //Kollar efter kollision med spelaren
    {
        if (collision.gameObject.name == "Player") 
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  //Kollar efter kollision med spelaren
	{
		if (collision.gameObject.name == "Player")
		{
			isInRange = false;
		}
	}
}

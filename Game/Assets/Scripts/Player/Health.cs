using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

	void Start()
	{
        currentHealth = maxHealth;
	}

	void Update()
	{
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            { 
                hearts[i].sprite = emptyHeart;
            }
        }
        if (currentHealth <= 0) 
        {
            die();
        }
	}

    public void takeDamage() 
    {
        currentHealth -= 1;

        //Fixa att att man tar damage som �r best�md f�r olika mobs, fixa animation
    }

    public void die() 
    {
        Debug.Log("Player died");
        //G�r Death Animation och g�r s� att spelet freezar samt till�t inte att �ppna pausemenyn
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

	void Update()
	{
        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else 
            { 
                hearts[i].sprite = emptyHeart;
            }
        }
	}

    public void takeDamage() 
    {
        health -= 1;
    }

    public void die() 
    {
        gameObject.SetActive(true);
    }
}

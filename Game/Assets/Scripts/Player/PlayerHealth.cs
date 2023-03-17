using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealthInterface
{
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	public Animator spriteAnimator;
	public GameObject gameOverPanel;

	[SerializeField]
	private int maxHealth = 4;
	private int currentHealth;


	[SerializeField]
	private bool inCombat = false;
	private float combatTimer = 10f;
	private float passedTime;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	private void Update()
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
	}
	public void Die()
	{
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;
	}

	public void takeDamage(int damage)
	{
		spriteAnimator.SetTrigger("takeDamage");
		passedTime = 0;
		inCombat = true;
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	private IEnumerator Regen()
	{
		if (!inCombat)
		{
			if (currentHealth < maxHealth)
			{
				currentHealth++;
			}
			yield return new WaitForSeconds(1f);
		}

		if (inCombat) 
		{ 
			
		}
	}
}

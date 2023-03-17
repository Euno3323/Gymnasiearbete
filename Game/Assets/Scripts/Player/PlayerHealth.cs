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
	private bool isRegenHealth;
	private float HealthRegenCooldownCounter;
	public float HealthRegenCooldown = 10f;
	private float takeDamageCooldownCounter;

	[SerializeField]
	private int maxHealth = 4;
	private int currentHealth;

	private void Awake()
	{
		currentHealth = maxHealth;
		takeDamageCooldownCounter = Time.deltaTime;
	}

	private void Update()
	{
		if (currentHealth <= maxHealth && HealthRegenCooldownCounter >= HealthRegenCooldown)
		{
			StartCoroutine(RegainHealthOverTime());
		}
		if (HealthRegenCooldownCounter < HealthRegenCooldown)
		{
			HealthRegenCooldownCounter = Time.deltaTime;
		}

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
		if (takeDamageCooldownCounter >= 0.5f)
		{
			takeDamageCooldownCounter = 0;
			spriteAnimator.SetTrigger("takeDamage");
			currentHealth -= damage;
			if (currentHealth <= 0)
			{
				Die();
			}
		}
		if (takeDamageCooldownCounter < 0.5)
		{
			takeDamageCooldownCounter += Time.deltaTime;
		}
	}
	private IEnumerable RegainHealthOverTime() {
		isRegenHealth = true;
		currentHealth += 1;
		yield return new WaitForSeconds(5f);
		isRegenHealth = false;
	}
}

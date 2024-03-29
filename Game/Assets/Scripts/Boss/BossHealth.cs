using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour, IHealthInterface
{
    [SerializeField]
	public int maxHealth = 20;
	private int currentHealth;
    public GameObject Wrapper;
    public Slider HealthBar;
	public GameObject endPanel;

	private void Awake()
	{
        Wrapper.SetActive(false);
		currentHealth = maxHealth;
        HealthBar.value = currentHealth;
        
	}
	public void Die()
	{
		Destroy(gameObject);
        Wrapper.SetActive(false);
		endPanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void takeDamage(int damage)
	{
		currentHealth -= damage;
        HealthBar.value = currentHealth;
		if (currentHealth <= 0)
		{
			Die();
		}
	}
}
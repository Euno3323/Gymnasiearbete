using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealth : MonoBehaviour
{
    //public Image healthBar;
    public float healthAmount;
    [Range(0.1f, 1000f)]public float maxHealth = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        healthAmount = maxHealth;
         rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        //healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);

        //healthBar.fillAmount = healthAmount / 100;
    }
}

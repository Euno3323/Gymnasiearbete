using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float healthAmount = 100f;
    [Range(0.1f, 1000f)]public float maxHealth = 100f;
    void Update()
    {
        if(healthAmount <= 0)
        {
            Debug.Log("restarting");
            Application.LoadLevel(Application.loadedLevel);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
            Debug.Log("20 dmg taken");
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
            Debug.Log("Healed 10hp");
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.value = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.value = healthAmount / 100;
    }
}

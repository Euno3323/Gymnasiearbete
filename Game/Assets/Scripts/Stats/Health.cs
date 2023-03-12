using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float MaxHealth;
    public float health => currentHealth;
    [SerializeField] protected float currentHealth;
    //så att andra skript kan se hälsan utan att ändra den

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public virtual void ChangeHealth(float amount)
    {
        float oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
        //OnHealthChanged?.Invoke(this, oldHealth, currentHealth);
    }
    public void TakeDamage(float damage){
        ChangeHealth(-damage);
        Debug.Log("damage Taken");
    }
    public void Heal(float health){
        ChangeHealth(health);
        Debug.Log("healed");
    }
    // Update is called once per frame
    void Update()
    {

    }
}

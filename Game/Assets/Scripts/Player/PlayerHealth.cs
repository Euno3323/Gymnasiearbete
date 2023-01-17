using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    //public static event OnPlayerDeath;
    public GameOverScreen GameOverScreen;
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        currentHealth = MaxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-5f);
        }
    }
    private Rigidbody2D m_Rigidbody2D;
    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
        if (currentHealth == 0)
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GameOverScreen.Setup(scene);


            //OnPlayerDeath?.Invoke();
        }
    }
}

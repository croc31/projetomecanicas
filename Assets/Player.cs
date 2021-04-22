using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    int currentHealth;

    bool isDead = false;

    private GameManager gameManager;
    private TintColor tintColor;

    void Start()
    {
        currentHealth = maxHealth;
        
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
        
        tintColor = GetComponent<TintColor>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void DoDamage()
    {
        TakeDamage(1);
    }
   
    public void TakeDamage(int damage)
    {
        tintColor.SetTintColor(new Color(255, 0, 0, 255));
        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth <= 0 && !isDead)
        {
            Die();
            Debug.Log("the player has been slayed");
        }
    }

    void Die()
    {
        isDead = true;
        //Animação de morte
        gameManager.Respawn();
        gameObject.GetComponentInParent<Destroy>().doDestroy();
    }
}

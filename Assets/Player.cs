using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public Transform spawnPoint;
    public int maxHealth = 100;
    int currentHealth;

    bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

   
    public void TakeDamage(int damage)
    {
        //Animação de levar dano
        currentHealth -= damage;

        if(healthBar != null)
            healthBar.SetHealth(currentHealth);

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
        //Destroy(gameObject);
        //respawn
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    int currentHealth;

    bool isDead = false;

    public GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //InvokeRepeating("DoDamage", 1f, 5f);
    }


    public void DoDamage()
    {
        TakeDamage(1);
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
        gameManager.Respawn();
        gameObject.GetComponentInParent<Destroy>().doDestroy();
    }
}

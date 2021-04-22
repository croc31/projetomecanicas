using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    int currentHealth;

    bool isDead = false;

    private GameManager gameManager;
    private TintColor tintColor;
    private CinemachineVirtualCamera cam;

    void Start()
    {
        currentHealth = maxHealth;
        
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
        
        tintColor = GetComponent<TintColor>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(cam == null)
        {
            Debug.Log("Setting camera");
            cam = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
            cam.m_Follow = gameObject.transform;
        }
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
        gameObject.GetComponentInParent<Destroy>().doDestroy();
        gameManager.Respawn();
    }
}

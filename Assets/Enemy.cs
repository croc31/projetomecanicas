using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;

        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(healthBar != null)
            healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    /*
    private void Drops()
    {
        if (thisDrop.LootItens != null) {
            for (int i = 0; i < thisDrop.LootItens.Length; ++i)
            {
                ItenQuantity currentIten = thisDrop.LootItens[i];
                if (currentIten != null)
                {
                    for (int j = 0; j < currentIten.quantity; ++j)
                    {
                        ItenDisplay display = new ItenDisplay();
                        display.SetIten(currentIten.thisloot);
                        Debug.Log("posi " + j + " item: " + display.thisIten.name);
                        Instantiate(display.gameObject, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }*/
    private void Die()
    {
       
        Destroy(gameObject);
    }

}

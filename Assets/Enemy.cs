using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public LootTable lootTable;
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
    
    private void Drop()
    {
        if (lootTable != null)
        {
            if(lootTable.quantity != 0 && lootTable.item != null){
                float xPos, yPos;
                GameObject droppedItem;
                xPos = GetComponent<Transform>().position.x;
                yPos = GetComponent<Transform>().position.y;
                for (int i = 0; i < lootTable.quantity; ++i)
                {
                    droppedItem = Instantiate(lootTable.item, new Vector3(xPos, yPos, -1), Quaternion.identity);
                    droppedItem.SetActive(true);
                }
                Debug.Log("Droppado");
            }
        }
    }

    private void Die()
    {
        
        Drop();
        Destroy(gameObject);
    }

}

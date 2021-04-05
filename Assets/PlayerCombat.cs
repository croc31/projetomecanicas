﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public HealthBar healthBar;

    public int attackDamage = 20;
    public  float attackRange = .5f;
    public float attackRate = 2f;
    public int maxHealth = 100;
    public LayerMask enemyLayers;
    public bool showGizmos = true;

    int currentHealth;
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        
        if(healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        //Animação de levar dano
        currentHealth -= damage;

        if(healthBar != null)
            healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
            Debug.Log("Jogador morreu");
        }
    }

    void Die()
    {
        //Animação de morte
        //Destroy(gameObject);
        //Respawn
    }

    void OnDrawGizmosSelected()
    {
        if(!showGizmos)
            return;
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

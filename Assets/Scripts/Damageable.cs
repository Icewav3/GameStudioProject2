﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Represents a damageable entity with health.
public class Damageable : MonoBehaviour
{
    [SerializeField] private float Maxhealth = 1f; // Maximum health.
    private float health; // Current health.

    // Events triggered on health change and death.
    public UnityEvent onHealthChanged;
    public UnityEvent onDeath;

    private GameObject healthBarObject; // Health bar game object.
    private Image healthBar; // Health bar image component.

    public void Start()
    {
        healthBarObject = GameObject.FindGameObjectWithTag("HealthSystem");
        healthBar = healthBarObject.GetComponent<Image>();
        health = Maxhealth;
    }

    // Reduces health and updates the health bar.
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / Maxhealth;
        onHealthChanged?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    // Handles the entity's death.
    protected virtual void Die()
    {
        onDeath?.Invoke();
    }
}
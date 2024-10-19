using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 1;
    [SerializeField] private string targetTag;
    private float _endTime;
    private BoxCollider2D _boxCollider;

    /// <summary>
    /// Initializes the bullet's properties and checks for required configurations.
    /// </summary>
    void Start()
    {
        /*if (targetTag == null)
        {
            Debug.LogWarning("Set target tag");
        }*/
        _boxCollider = GetComponent<BoxCollider2D>();
        _endTime = Time.time + lifetime;
    }

    /// <summary>
    /// Update bullet lifetime
    /// </summary>
    void Update()
    {
        if (Time.time > _endTime)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Handles collision events between the bullet and other 2D colliders.
    /// </summary>
    /// <param name="other">The collision information of the other collider.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (targetTag == null || other.gameObject.CompareTag(targetTag))
        {
            Damageable damageable = other.gameObject.GetComponent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}

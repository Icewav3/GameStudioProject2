using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject projectile;
    public float verticalOffset = 0.5f;
    public float fireRate = 0.3f;
    //public AudioSource shoot;
    private float _speed = 500;

    private float _nextFire = 0;
    /// <summary>
    /// Basic Shooter defaults to firing away from the center of the world position
    /// </summary>
    void Update()
    {
        if (Time.time >= _nextFire)
        {
            GameObject bullet = Instantiate(projectile, transform.position, quaternion.identity);
            //shoot.Play();
            Rigidbody2D bulletRg = bullet.GetComponent<Rigidbody2D>();
            Vector3 direction = (transform.position.x > 0 ? transform.right : -transform.right);
            SpriteRenderer sprite = bullet.GetComponentInChildren<SpriteRenderer>();
            sprite.flipX = (transform.position.x > 0 ? false : true);
            bulletRg.AddForce(direction*_speed);
            _nextFire = Time.time + fireRate;
        }
    }
}
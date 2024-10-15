using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject Projectile;
    public float _verticalOffset = 0.5f;
    public float fireRate = 0.3f;
    public AudioSource shoot;
    private float _speed = 500;

    private float nextFire = 0;
    /// <summary>
    /// SimpleShooter uses left mouse input and a basic fire delay to instantiate bullets and add force to them in the direction we are facing.
    /// </summary>
    void Update()
    {
        if (Time.time >= nextFire)
        {
            GameObject bullet = Instantiate(Projectile, transform.position, quaternion.identity);
            //shoot.Play();
            var bulletRg = bullet.GetComponent<Rigidbody2D>();
            bulletRg.AddForce(transform.up*_speed);
            nextFire = Time.time + fireRate;
        }
    }
}
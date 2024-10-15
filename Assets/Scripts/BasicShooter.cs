using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject Projectile;
    public float _verticalOffset = 0.5f;
    public float fireRate = 0.3f;
    //public AudioSource shoot;
    private float _speed = 500;

    private float nextFire = 0;
    /// <summary>
    /// Basic Shooter defaults to firing away from the center of the world position
    /// </summary>
    void Update()
    {
        if (Time.time >= nextFire)
        {
            GameObject bullet = Instantiate(Projectile, transform.position, quaternion.identity);
            //shoot.Play();
            var bulletRg = bullet.GetComponent<Rigidbody2D>();
            var direction = (transform.position.x > 0 ? transform.right : -transform.right);
            bulletRg.AddForce(direction*_speed);
            nextFire = Time.time + fireRate;
        }
    }
}
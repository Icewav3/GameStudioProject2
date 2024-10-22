using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerHouse : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] private Rigidbody2D rb;
    void FixedUpdate()
    {
        rb.velocity = speed * (transform.position.x > 0 ? -transform.right : transform.right);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), speed * Time.fixedDeltaTime);
    }
}
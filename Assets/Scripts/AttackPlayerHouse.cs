using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerHouse : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(0, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
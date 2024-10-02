using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private Rigidbody2D _rg;
    private GameObject _playerArt;
    private Vector3 _playerInput;

    void Start()
    {
        //_rg = this.GetComponentInChildren<Rigidbody2D>();
        //_playerArt = this.transform.Find("TankArt").gameObject;
    }
    /// <summary>
    /// Get player input
    /// </summary>
    void Update()
    {
        _playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
    /// <summary>
    /// face player toward movement direction and linearly translate players position over time
    /// </summary>
    private void FixedUpdate()
    {
        transform.position += _playerInput * (speed * Time.deltaTime); 
    }
}
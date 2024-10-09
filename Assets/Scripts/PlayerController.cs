using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private Rigidbody2D _rg;
    private GameObject _playerArt;

    private PlayerInput playerControls;
    private InputAction move;
    private InputAction plant;
    private float moveInput;
    public bool plantWasPressed;


    private void Awake()
    {
        playerControls = new PlayerInput();
    }

    private void OnEnable()
    {
        move = playerControls.MouseKeyboard.Move;
        move.Enable();
        plant = playerControls.MouseKeyboard.Plant;
        plant.Enable();

        plant.started += OnPlantStarted;
        plant.canceled += OnPlantCancelled;
        
    }

    private void OnDisable()
    {
        move.Disable();
        plant.Disable();
    }
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
        moveInput = move.ReadValue<float>();

        transform.position += new Vector3(moveInput, 0, 0) * (speed * Time.deltaTime);
    }

    public void OnPlantStarted(InputAction.CallbackContext context)
    {
        plantWasPressed = true;
    }

    public void OnPlantCancelled(InputAction.CallbackContext context)
    {
        plantWasPressed = false;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    //private Rigidbody2D _rg;
    [SerializeField]
    private GameObject _playerArtObject;
    private SpriteRenderer _playerArt;
    
    private PlayerInput playerControls;
    private InputAction move;
    private InputAction plant;
    private float moveInput;
    public bool plantWasPressed;


    private void Awake()
    {
        playerControls = new PlayerInput();
        _playerArt = _playerArtObject.GetComponent<SpriteRenderer>();
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

    private void OnDisable() //are we disabling player controller?
    {
        move.Disable();
        plant.Disable();
    }
    /// <summary>
    /// Get player input
    /// </summary>
    void Update()
    {
        moveInput = move.ReadValue<float>();
        transform.position += new Vector3(moveInput, 0, 0) * (speed * Time.deltaTime);
        _playerArt.flipX = moveInput < 0 ? true : false;
    }

    private void OnPlantStarted(InputAction.CallbackContext context)
    {
        plantWasPressed = true;
    }

    private void OnPlantCancelled(InputAction.CallbackContext context)
    {
        plantWasPressed = false;
    }
}
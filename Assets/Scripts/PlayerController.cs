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
    private InputAction plant1;
    private InputAction plant2;
    private InputAction plant3;
    public float moveInput;
    public bool plant1WasPressed;
    public bool plant2WasPressed;
    public bool plant3WasPressed;


    private void Awake()
    {
        playerControls = new PlayerInput();
        _playerArt = _playerArtObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        move = playerControls.MouseKeyboard.Move;
        move.Enable();
        plant1 = playerControls.MouseKeyboard.Plant1;
        plant1.Enable();
        plant1.started += OnPlant1Started;
        plant1.canceled += OnPlant1Cancelled;

        plant2 = playerControls.MouseKeyboard.Plant2;
        plant2.Enable();
        plant2.started += OnPlant2Started;
        plant2.canceled += OnPlant2Cancelled;

        plant3 = playerControls.MouseKeyboard.Plant3;
        plant3.Enable();
        plant3.started += OnPlant3Started;
        plant3.canceled += OnPlant3Cancelled;

    }

    private void OnDisable() //are we disabling player controller?
    {
        move.Disable();
        plant1.Disable();
        plant2.Disable();
        plant3.Disable();
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

    private void OnPlant1Started(InputAction.CallbackContext context)
    {
        plant1WasPressed = true;

    }

    private void OnPlant1Cancelled(InputAction.CallbackContext context)
    {
        plant1WasPressed = false;
    }

    private void OnPlant2Started(InputAction.CallbackContext context)
    {
        plant2WasPressed = true;

    }

    private void OnPlant2Cancelled(InputAction.CallbackContext context)
    {
        plant2WasPressed = false;
    }

    private void OnPlant3Started(InputAction.CallbackContext context)
    {
        plant3WasPressed = true;

    }

    private void OnPlant3Cancelled(InputAction.CallbackContext context)
    {
        plant3WasPressed = false;
    }
}
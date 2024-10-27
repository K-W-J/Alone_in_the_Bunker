using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private Vector2 _moveDir;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.KeyBoard.Jump.performed += Jump;
        _playerInput.KeyBoard.Movement.performed += _ => _moveDir = _.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        _rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Movement();

    }

    private void Movement()
    {
        _rb.velocity = new Vector3(_moveDir.x, _rb.velocity.y, _moveDir.y);
    }
}

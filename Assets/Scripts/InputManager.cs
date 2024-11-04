using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private PlayerCameraRotation playerCameraRotation;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCameraRotation = GetComponentInChildren<PlayerCameraRotation>();

        playerInput = new PlayerInput();
        playerInput.KeyBoard.Jump.performed += e => playerMovement.Jump();
    }

    private void Update()
    {
        playerMovement.Movement(playerInput.KeyBoard.Movement.ReadValue<Vector2>());
        playerCameraRotation.MouseRotation(playerInput.KeyBoard.CameraMovement.ReadValue<Vector2>().x, playerInput.KeyBoard.CameraMovement.ReadValue<Vector2>().y);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

}

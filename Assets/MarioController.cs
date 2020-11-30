using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Hola();

public class MarioController : MonoBehaviour
{

    InputMario input;
    private void Awake()
    {
        input = new InputMario();
        input.Maincontroller.Jump.performed += OnJump;
        input.Maincontroller.Movement.performed += OnMove;
    }
    private void OnDisable()
    {
        input.Maincontroller.Jump.performed -= OnJump;
    }


    private void OnMove(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        obj.ReadValue<Vector2>();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float linearSpeed = 10f;
    public Rigidbody body;
    private Vector2 movementVector = Vector2.zero;

    void Awake()
    {
        if (!body)
        {
            body = GetComponent<Rigidbody>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
        // Debug.Log($"Indo para {movementVector}");
    }

    void FixedUpdate()
    {
        body.AddForce(transform.forward * movementVector.y + transform.right * movementVector.x);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        // Debug.Log("OLARS");
        var movementVector = context.ReadValue<Vector2>();
        Debug.Log($"OLARS {movementVector}");
    }
}

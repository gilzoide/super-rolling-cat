using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PrintMovement : MonoBehaviour
{
    public Text text;

    public void OnMove(InputAction.CallbackContext context)
    {
        text.text = context.ReadValue<Vector2>().ToString();
    }
}

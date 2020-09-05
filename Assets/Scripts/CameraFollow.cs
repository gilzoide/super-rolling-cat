using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float rotateSpeed = 4f;
    
    private Vector3 offset;
    private Vector3 velocity;
    private Vector2 movementVector = Vector2.zero;

    void Start()
    {
        offset = transform.position - target.position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // transform.RotateAround(target.position, Vector3.up, rotateSpeed * movementVector.x * Time.deltaTime);
        
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
        transform.LookAt(target.position);
    }
}

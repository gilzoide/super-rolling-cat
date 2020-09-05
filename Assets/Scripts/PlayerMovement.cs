using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float linearSpeed = 10f;
    public float angularSmoothTime = 0.3f;
    public Transform movementDirectionBase;
    public Rigidbody body;

    private Vector2 movementVector = Vector2.zero;
    private Vector3 velocity;

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

    void Update()
    {
        transform.position = body.transform.position;
        var forward = transform.forward;
        var velocityForward = body.velocity;
        velocityForward.x += (velocityForward.x > 0.001f ? 0f : 1f) * forward.x;
        velocityForward.z += (velocityForward.z > 0.001f ? 0f : 1f) * forward.z;
        transform.rotation = Quaternion.LookRotation(Vector3.SmoothDamp(forward, velocityForward, ref velocity, angularSmoothTime));
    }

    void FixedUpdate()
    {
        body.AddForce(movementDirectionBase.forward * movementVector.y + movementDirectionBase.right * movementVector.x);
    }
}

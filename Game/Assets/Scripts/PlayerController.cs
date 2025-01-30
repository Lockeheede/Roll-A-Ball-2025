using System;
using UnityEngine;
using UnityEngine.InputSystem; // Required for InputSystem

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0; // Speed variable that can be set in the Unity Editor
    private Rigidbody rb; // Reference to the Rigidbody component
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component and set it to the rb variable.
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Get the movement vector from the input
        movementX = movementVector.x; // Set the movementX variable to the x value of the movement vector
        movementY = movementVector.y; // Set the movementY variable to the y value of the movement vector
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Create a new Vector3 with the movement values

        rb.AddForce(movement * speed); // Add a force to the Rigidbody component
    }

}

using System;
using UnityEngine;
using UnityEngine.InputSystem; // Required for InputSystem
using TMPro; // Required for TextMeshPro

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0; // Speed variable that can be set in the Unity Editor
    public TextMeshProUGUI countText; // Reference to the TextMeshProUGUI component
    public GameObject winTextObject; // Reference to the GameObject component
    private Rigidbody rb; // Reference to the Rigidbody component
    private int count;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component and set it to the rb variable.
        count = 0; // Set the count variable to 0

        SetCountText(); // Call the SetCountText function
        winTextObject.SetActive(false); // Set the winTextObject to inactive
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Get the movement vector from the input
        movementX = movementVector.x; // Set the movementX variable to the x value of the movement vector
        movementY = movementVector.y; // Set the movementY variable to the y value of the movement vector
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString(); // Set the text of the countText to "Count: " + the value of the count variable
        if(count >= 12)
        {
            winTextObject.SetActive(true); // Set the winTextObject to active
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Create a new Vector3 with the movement values

        rb.AddForce(movement * speed); // Add a force to the Rigidbody component
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) // Check if the object that the player collided with has the tag "PickUp"
        {
            other.gameObject.SetActive(false); // Set the object that the player collided with to inactive
            count++; // Increment the count variable
            SetCountText(); // Call the SetCountText function
        }
    }

}

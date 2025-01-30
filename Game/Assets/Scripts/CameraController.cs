using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Public variable to store a reference to the player game object
    private Vector3 offset; // Private variable to store the offset distance between the player and camera

    void Start()
    {
        offset = transform.position - player.transform.position; // Calculate the initial offset value
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player, but offset by the calculated offset distance
        transform.position = player.transform.position + offset;
    }
}

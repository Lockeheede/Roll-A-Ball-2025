using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); // Rotate the object by 15, 30, and 45 degrees on the x, y, and z axes respectively
    }
}

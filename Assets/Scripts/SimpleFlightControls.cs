using UnityEngine;

public class SimpleFlightControls : MonoBehaviour
{
    private Rigidbody rb;
    private Quaternion initialRotation;
    public float moveSpeed = 5f;
    public float rotationSpeed = 30f;
    public float slowDownSpeed = 2f; // Speed at which forward momentum decreases and goes into reverse

    private float currentSpeed = 0f; // Current forward/backward speed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Forward movement
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, slowDownSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, -moveSpeed, slowDownSpeed * Time.deltaTime);
        }
        else
        {
            // Gradually slow down to a stop if neither W nor S is pressed
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, slowDownSpeed * Time.deltaTime);
        }

        // Update position based on currentSpeed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Rotation left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        // Rotation right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Debug statements
        Debug.Log("Current Speed: " + currentSpeed);
        Debug.Log("Rotation: " + transform.rotation.eulerAngles);
    }

    private void FixedUpdate()
    {
        // Check for user input (e.g., left or right rotation)
        float rotationInput = Input.GetAxis("Horizontal");

        // If no input, apply counter-rotation to prevent drift
        if (Mathf.Approximately(rotationInput, 0f))
        {
            // Calculate the rotation needed to return to the initial rotation
            Quaternion counterRotation = Quaternion.Inverse(transform.rotation) * initialRotation;

            // Convert the rotation to torque and apply it to the rigidbody
            rb.AddTorque(rotationSpeed * counterRotation.eulerAngles * Mathf.Deg2Rad);
        }

        // Debug statement
        Debug.Log("Rotation Input: " + rotationInput);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;  // The empty GameObject to follow
    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;

    private float currentSpeed = 0f;

    void Update()
    {
        // Get input from the mouse scroll wheel to adjust speed
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentSpeed += scrollInput * moveSpeed;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, moveSpeed);  // Clamp speed to prevent negative values

        // Calculate the direction vector towards the target
        Vector3 targetDirection = (target.position - transform.position).normalized;

        // Rotate towards the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move forward or backward based on currentSpeed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}

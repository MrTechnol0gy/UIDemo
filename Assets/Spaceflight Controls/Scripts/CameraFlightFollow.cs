using UnityEngine;

public class CameraFlightFollow : MonoBehaviour
{
    public Transform target; // What the camera looks at. Generally the targeter.
    public SimpleFlightControls control; // The PlayerFlightControl script that is in play.

    public float follow_distance = 3.0f; // How far behind the camera will follow the targeter.
    public float camera_elevation = 3.0f; // How high the camera will rise above the targeter's Z axis.
    public float follow_tightness = 5.0f; // How closely the camera will follow the target. Higher values are snappier, lower results in a more lazy follow.

    public static CameraFlightFollow instance; // The instance of this class. Should only be one.

    private Quaternion initialRotation; // Store the initial rotation of the camera.

    private void Awake()
    {
        instance = this;
        initialRotation = transform.rotation; // Store the initial rotation of the camera.
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogError("(Flight Controls) Camera target is null!");
            return;
        }

        if (control == null)
        {
            Debug.LogError("(Flight Controls) Flight controller is null on camera!");
            return;
        }

        // Calculate where we want the camera to be.
        Vector3 newPosition = target.TransformPoint(camera_elevation, -follow_distance, follow_tightness);

        // Get the difference between the current location and the target's current location.
        Vector3 positionDifference = target.position - transform.position;
        
        // Only update camera position based on target movement.
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * follow_tightness);

        // Calculate the rotation needed to return to the initial rotation.
        Quaternion counterRotation = Quaternion.Inverse(transform.rotation) * initialRotation;

        // Calculate the rotation to apply based on the counterRotation.
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime);

        // Update the camera's rotation.
        transform.rotation = newRotation;
    }
}

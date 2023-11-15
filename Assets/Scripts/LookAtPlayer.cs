using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform objectToRotate; // The object that will look at the player

    void Update()
    {
        if (player != null && objectToRotate != null)
        {
            // Calculate the direction from the object to the player
            Vector3 lookDirection = objectToRotate.position - player.position;

            // Use Quaternion.LookRotation to face away from the player
            objectToRotate.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}

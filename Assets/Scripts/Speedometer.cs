using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public GameObject ship; // Reference to the player's ship GameObject.
    public Transform referencePoint; // Reference point for the speedometer on the ship.
    public Image speedometerGauge; // The gauge image.
    public TextMeshProUGUI speedText; // Text element for displaying the speed.

    void Update()
    {        
        if (ship == null)
        {
            // Find the player's ship by tag.
            ship = GameObject.Find("Ship Container");
        }
        // Check if ship is null (in case it's destroyed or not assigned).
        else if (ship != null)
        {
            // set the reference point
            referencePoint = ship.transform.Find("Speedometer");
            // Update the position and rotation of the speedometer based on the ship's reference point.
            transform.position = referencePoint.position;
            transform.rotation = referencePoint.rotation;

            // Get the ship's speed (adjust this based on how you calculate speed in your game).
            float shipSpeed = ship.GetComponent<AdvFlightControls>().getSpeed();

            // Update the displayed speed value.
            speedText.text = shipSpeed.ToString("F0") + " m/s";
        }
    }
}

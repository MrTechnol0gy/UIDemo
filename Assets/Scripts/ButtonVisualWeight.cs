using UnityEngine;
using UnityEngine.UI;

public class ButtonVisualWeight : MonoBehaviour
{
    public Button[] importantButton;
    public Color color;
    public Vector2 effectDistance;

    void Start()
    {
        // Loop through all the buttons
        foreach (Button button in importantButton)
        {
            // Increase the size of the important button
            button.transform.localScale *= 1.5f;

            // Ensure the button has an Image component (required for Outline)
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage == null)
            {
                buttonImage = button.gameObject.AddComponent<Image>();
            }

            // Add or get the Outline component
            Outline outline = button.GetComponent<Outline>();
            if (outline == null)
            {
                outline = button.gameObject.AddComponent<Outline>();
            }

            // Set the outline color to black
            outline.effectColor = color;
            outline.effectDistance = effectDistance;
        }        
    }
}

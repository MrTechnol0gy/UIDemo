using UnityEngine;
using UnityEngine.UI;

public class ColorAdjustment : MonoBehaviour
{
    public Slider colorSlider;
    public Image backgroundImage;

    void Start()
    {
        // Add a listener to the slider's value changed event.
        colorSlider.onValueChanged.AddListener(ChangeBackgroundColor);
    }

    void ChangeBackgroundColor(float colorValue)
    {
        // Generate a random hexadecimal color value.
        string hexColor = GetRandomHexColor();

        // Convert the hexadecimal color to a Unity Color.
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            // Set the background image's color to the new color.
            backgroundImage.color = newColor;
        }
    }

    string GetRandomHexColor()
    {
        // Generate a random color by creating a random hexadecimal value.
        Color32 randomColor = new Color32(
            (byte)Random.Range(0, 256), // R
            (byte)Random.Range(0, 256), // G
            (byte)Random.Range(0, 256), // B
            255 // Alpha (fully opaque)
        );

        // Convert the Color32 to a hexadecimal string.
        return ColorUtility.ToHtmlStringRGB(randomColor);
    }
}

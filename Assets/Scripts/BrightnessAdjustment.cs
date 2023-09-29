using UnityEngine;
using UnityEngine.UI;

public class BrightnessAdjustment : MonoBehaviour
{
    public Slider brightnessSlider;
    public Material targetMaterial; // The material you want to adjust (e.g., on a RenderTexture or object in your scene).
    private float initialBrightness; // Store the initial brightness for reference.

    void Start()
    {
        // Store the initial brightness of the material.
        initialBrightness = targetMaterial.GetFloat("_Brightness");

        // Add a listener to the slider's value changed event.
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
    }

    void ChangeBrightness(float brightnessValue)
    {
        // Update the material's brightness property based on the slider value.
        targetMaterial.SetFloat("_Brightness", brightnessValue);
    }

    public void ResetBrightness()
    {
        // Reset the brightness to its initial value.
        targetMaterial.SetFloat("_Brightness", initialBrightness);
        brightnessSlider.value = initialBrightness;
    }
}

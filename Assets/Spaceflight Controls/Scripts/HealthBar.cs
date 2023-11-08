using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Reference to the Slider
    public Slider slider;

    void Start()
    {
        // Set the slider to the max value
        slider.value = slider.maxValue;
    }
    void Update()
    {
        // If Keypress "H" is detected, reduce the slider value by 10
        if (Input.GetKeyDown(KeyCode.H))
        {
            slider.value -= 10;
        }
        // If the Keypress "J" is detected, increase the slider value by 10
        if (Input.GetKeyDown(KeyCode.J))
        {
            slider.value += 10;
        }
    }
}

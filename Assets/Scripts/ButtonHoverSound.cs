using UnityEngine;
using System.Collections;

public class ButtonHoverSound : MonoBehaviour
{
    public AudioClip hoverSound; 
    public AudioSource audioSource;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip
        audioSource.clip = hoverSound;
    }

    private void OnMouseEnter()
    {
        // Play the hover sound when the mouse enters the button area
        audioSource.Play();
    }
}

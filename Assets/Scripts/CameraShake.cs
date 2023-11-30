using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera; 
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 0.5f;

    private bool isShaking = false;
    private Vector3 originalPosition;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalPosition = mainCamera.transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // If the player is holding down the W key, shake the camera
        {
            StartCoroutine(Shake());
        }
        else
        {
            isShaking = false;
            mainCamera.transform.localPosition = originalPosition;
        }
    }

    IEnumerator Shake()
    {
        isShaking = true;
        Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
        mainCamera.transform.localPosition = originalPosition + shakeOffset;
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAffectingOrb : MonoBehaviour
{
    private bool thisOrbHeals = false;

    void Awake()
    {
        // Randomly decide if this orb heals or damages
        thisOrbHeals = Random.Range(0, 2) == 0;
    }

    void Start()
    {
        if (thisOrbHeals)
        {
            // Set this orb's material to be green
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            // Set this orb's material to be red
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    // Collider to detect player collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if this orb heals, heal the player
            if (thisOrbHeals)
            {
                UIManager.instance.IncreaseHealth();
            }
            // if this orb damages, damage the player
            else
            {
                UIManager.instance.DecreaseHealth();
            }
            UIManager.instance.UpdateProgressBar(1);
            
            // Destroy the object after collision
            Destroy(gameObject);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public int numberOfSpheres = 10; // Adjust the number of spheres as needed
    public float areaSize = 100f; // Adjust the size of the area
    public GameObject spherePrefab; // Assign your sphere prefab in the Inspector

    private List<GameObject> spheresList = new List<GameObject>();

    void Start()
    {
        InstantiateSpheres();
    }

    private void InstantiateSpheres()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-areaSize, areaSize), Random.Range(-areaSize, areaSize), Random.Range(-areaSize, areaSize));
            GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            // scale the sphere up three times
            sphere.transform.localScale = new Vector3(3, 3, 3);
            spheresList.Add(sphere);
        }
    }

    // Method to get the list of spheres
    public List<GameObject> GetSpheresList()
    {
        return spheresList;
    }
}

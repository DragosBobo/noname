using System.Collections;
using UnityEngine;

public class ClientSpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to instantiate
    public Transform[] spawnPoints; // Array of spawn points

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomDelay = Random.Range(3f, 10f); // Random delay between 3 to 10 seconds
            yield return new WaitForSeconds(randomDelay);

            SpawnAtRandomPoint();
        }
    }

   private void SpawnAtRandomPoint()
    {
        // Filter free spawn points
        var freeSpawnPoints = new System.Collections.Generic.List<Transform>();

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.childCount == 0) // Check if the spot is free
            {
                freeSpawnPoints.Add(spawnPoint);
            }
        }

        if (freeSpawnPoints.Count > 0) // If there are free spawn points
        {
            // Pick a random free spawn point
            Transform chosenSpawnPoint = freeSpawnPoints[Random.Range(0, freeSpawnPoints.Count)];

            // Instantiate the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, chosenSpawnPoint.position, chosenSpawnPoint.rotation);

            // Reset the scale to the original prefab scale
            spawnedPrefab.transform.localScale = prefabToSpawn.transform.localScale;

            // Optionally parent it to the spawn point to keep the hierarchy clean
            spawnedPrefab.transform.parent = chosenSpawnPoint;
        }
    }

}
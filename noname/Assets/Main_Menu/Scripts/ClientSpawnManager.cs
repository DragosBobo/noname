using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public Transform[] spawnPoints;

    private Dictionary<Transform, float> _occupiedSpawnPoints = new Dictionary<Transform, float>();
    private List<Transform> _freeSpawnPoints = new List<Transform>();

    private void Start()
    {
        if (prefabsToSpawn.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogError("Prefabs to spawn or spawn points are not assigned!");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Wait for a random time between 3 and 10 seconds (original delay)
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            SpawnAtRandomPoint();
        }
    }

    private void SpawnAtRandomPoint()
    {
        _freeSpawnPoints.Clear(); // Reuse the list to avoid allocations

        float currentTime = Time.time;
        float requiredDelay = Random.Range(2f, 5f); // Delay to consider a spawn point free again

        foreach (var spawnPoint in spawnPoints)
        {
            // Check if the spawn point is not occupied or if it has been occupied for long enough
            if (!_occupiedSpawnPoints.TryGetValue(spawnPoint, out float lastOccupiedTime) ||
                (currentTime - lastOccupiedTime >= requiredDelay))
            {
                _freeSpawnPoints.Add(spawnPoint);
            }
        }

        if (_freeSpawnPoints.Count > 0)
        {
            // Pick a random spawn point from the free spawn points
            Transform chosenSpawnPoint = _freeSpawnPoints[Random.Range(0, _freeSpawnPoints.Count)];

            // Pick a random prefab from the array
            GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

            // Spawn the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
            spawnedPrefab.transform.localScale = prefabToSpawn.transform.localScale;
            spawnedPrefab.transform.parent = chosenSpawnPoint;

            // Mark the spawn point as occupied and record the current time
            _occupiedSpawnPoints[chosenSpawnPoint] = currentTime;
        }
        else
        {
            Debug.LogWarning("No free spawn points available!");
        }
    }
}
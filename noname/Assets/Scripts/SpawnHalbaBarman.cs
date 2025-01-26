using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHalbaBarman : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints; // Array de puncte Empty
    [SerializeField] private GameObject prefabToSpawn; // Prefab-ul care urmează să fie spawnat
    [SerializeField] private float minSpawnTime = 3f; // Timp minim între spawn-uri
    [SerializeField] private float maxSpawnTime = 6f; // Timp maxim între spawn-uri

    private bool[] isOccupied; // Array pentru a verifica dacă un punct este ocupat

    private void Start()
    {
        // Inițializăm array-ul pentru starea de ocupare
        isOccupied = new bool[spawnPoints.Length];

        // Începem procesul de verificare și spawn
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Așteptăm un timp aleator între minSpawnTime și maxSpawnTime
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Colectăm toate punctele libere
            List<int> freePoints = new List<int>();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (!isOccupied[i]) // Dacă punctul nu este ocupat
                {
                    freePoints.Add(i); // Adăugăm punctul în lista de puncte libere
                }
            }

            // Dacă există puncte libere, alegem unul aleator
            if (freePoints.Count > 0)
            {
                int randomIndex = freePoints[Random.Range(0, freePoints.Count)];
                SpawnPrefab(randomIndex); // Spawnăm pe poziția aleasă
            }
        }
    }

    private void SpawnPrefab(int index)
    {
        // Debug pentru a verifica pozițiile utilizate
        Debug.Log($"Spawnăm un obiect la punctul {index}");

        // Instanțiem prefab-ul la poziția și rotația punctului
        Instantiate(prefabToSpawn, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);

        // Marcăm punctul ca fiind ocupat
        isOccupied[index] = true;

        // Pornim un Coroutine pentru a elibera punctul după o anumită acțiune
        StartCoroutine(ReleasePoint(index));
    }

    private IEnumerator ReleasePoint(int index)
    {
        // Simulăm o acțiune înainte de a elibera punctul (de exemplu, 5 secunde)
        yield return new WaitForSeconds(5f);

        // Marcăm punctul ca fiind liber
        isOccupied[index] = false;

        // Debug pentru confirmare
        Debug.Log($"Punctul {index} a fost eliberat.");
    }
}

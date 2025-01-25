using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool isTriggered = false;
    public GameObject prefabToSpawn; // Prefabul care va fi instanțiat
    public Transform spawnLocation;  // Locația unde va fi spawnat obiectul

    void Update()
    {
        if (isTriggered)
        {
            // Codul pentru ce se întâmplă când variabila devine true
            Debug.Log("Triggered!");

            // Verifică dacă există prefab-ul și locația
            if (prefabToSpawn != null && spawnLocation != null)
            {
                // Spawnează prefab-ul la locația dorită
                Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation);
            }

            // Oprește spawn-ul pentru a nu se întâmpla la fiecare frame
            isTriggered = false; // Sau poți pune o altă condiție de resetare
        }
    }
}

using UnityEngine;

public class TriggerSpawnBere : MonoBehaviour
{
    public GameObject targetPrefab; // Obiectul care va primi schimbarea valorii bool

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificăm dacă a lovit player-ul (poți schimba tag-ul după necesități)
        {
            // Găsește scriptul din targetPrefab și activează variabila bool
            if (targetPrefab != null)
            {
                var targetScript = targetPrefab.GetComponent<TargetScript>(); // Presupunem că există un script numit TargetScript
                if (targetScript != null)
                {
                    targetScript.isTriggered = true; // Modifică variabila bool
                }
            }
        }
    }
}

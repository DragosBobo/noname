using UnityEngine;

public class pastreazapozitialabere : MonoBehaviour
{
    public Transform emptyObject;  // Obiectul gol (Empty GameObject) care definește locația

    void Update()
    {
        if (emptyObject != null)
        {
            // Menține poziția obiectului curent la poziția obiectului gol
            transform.position = emptyObject.position;

            // Dacă vrei să menții și rotația:
            transform.rotation = emptyObject.rotation;

            // Dacă vrei să menții și scala:
            transform.localScale = emptyObject.localScale;
        }
    }
}

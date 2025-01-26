using UnityEngine;

public class AlwaysFace : MonoBehaviour
{
    public Camera targetCamera; // Camera față de care va sta quad-ul
    public float distanceFromCamera = 2f; // Distanța față de cameră

    void Start()
    {
        if (targetCamera == null)
        {
            // Dacă nu este setată manual, utilizăm camera principală
            targetCamera = Camera.main;
        }
    }

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            // Setează poziția quad-ului mereu în fața camerei
            Vector3 forwardDirection = targetCamera.transform.forward;
            Vector3 cameraPosition = targetCamera.transform.position;

            transform.position = cameraPosition + forwardDirection * distanceFromCamera;

            // Setează orientarea quad-ului spre camera (quad-ul "privește" camera)
            transform.rotation = Quaternion.LookRotation(forwardDirection);
        }
    }
}

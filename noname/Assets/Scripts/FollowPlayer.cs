using TMPro;
using UnityEngine;

public class Platou : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, -1, -2); 
    public float followSpeed = 5f; 

    private Vector3 targetPosition;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (player != null)
        {
            targetPosition = player.position + player.forward * offset.z + player.up * offset.y + player.right * offset.x;

            // transform.position = targetPosition;
            // float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
    }
}

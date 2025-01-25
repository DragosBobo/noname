using TMPro;
using UnityEngine;

public class Platou : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, -1, -2); 
    public float followSpeed = 5f; 
    public float minDistance = 1f; 

    private Vector3 targetPosition; 

    void Update()
    {
        if (player != null)
        {
            targetPosition = player.position + player.forward * offset.z + player.up * offset.y + player.right * offset.x;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > minDistance)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
            }
        }
    }
}

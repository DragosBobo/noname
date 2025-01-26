using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator animator;
    public float countdownTime = 0.2f;
    public float volume = 0.2f;

    [SerializeField]
    private GameObject targetObject; // Renamed 'pl' to 'targetObject' for clarity
    [SerializeField]
    private AudioClip bombExplosion;

    private bool isCountdownFinished = false;
    public bool IsCountdownFinished => isCountdownFinished; // Public read-only property

    void Start()
    {
        animator = GetComponent<Animator>();
     
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on this GameObject.", this);
        }

   

        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned in the Timer script.", this);
        }

        //StartCoroutine(StartCountdown());

    }


    public void Explode()
    {
        AudioManager.Instance.PlayAudio(bombExplosion);
        if (targetObject != null)
        {
            Destroy(targetObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
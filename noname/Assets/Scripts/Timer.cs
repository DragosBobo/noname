using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator animator;
    public float countdownTime = 0.2f;

    [SerializeField]
    private GameObject targetObject; // Renamed 'pl' to 'targetObject' for clarity
    private AudioSource audioSource;

    private bool isCountdownFinished = false;
    public bool IsCountdownFinished => isCountdownFinished; // Public read-only property

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on this GameObject.", this);
        }

        if (audioSource != null)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            Debug.LogWarning("AudioSource component is missing on this GameObject.", this);
        }

        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned in the Timer script.", this);
        }
    }

    void Update()
    {
        // Ensure the coroutine is only started once
        if (!isCountdownFinished && IsAnimationFinished("Boomb"))
        {
            StartCoroutine(StartCountdown());
            isCountdownFinished = true; // Set this to true immediately to prevent multiple coroutine starts
        }
    }

    private bool IsAnimationFinished(string animationName)
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator is not assigned.", this);
            return false;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    private System.Collections.IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownTime);
        Debug.Log("Countdown finished!");

        // Play the sound before destroying the object
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (targetObject != null)
        {
            Destroy(targetObject);
        }

        Destroy(gameObject);
    }
}
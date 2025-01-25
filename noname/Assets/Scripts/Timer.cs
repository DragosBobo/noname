using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator animator;
    public bool isCountdownFinished = false;

    public float countdownTime = 2.0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on this GameObject.");
        }
    }

    void Update()
    {
        if (!isCountdownFinished && IsAnimationFinished("Boomb"))
        {
            StartCoroutine(StartCountdown());
        }
    }

    private bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    private System.Collections.IEnumerator StartCountdown()
    {
        isCountdownFinished = true; 
        yield return new WaitForSeconds(countdownTime);
        Debug.Log("Countdown finished!");
    
}
}

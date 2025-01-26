using UnityEngine;
using System.Collections;
using UnityEditor;

public class AnimationFillAmountScript : MonoBehaviour
{
    public float countdownTime = 2f; // Durata până când fill scade complet
    public float volume = 0.2f;

    [SerializeField]
    private GameObject targetObject; // Obiectul care va fi distrus
    [SerializeField]
    private AudioClip bombExplosion; // Sunetul de explozie

    private Material material; // Materialul pentru animația FillAmount
    private float timer; // Timer pentru countdown
    private bool isCountdownFinished = false; // Dacă countdown-ul s-a terminat

    public bool IsCountdownFinished => isCountdownFinished; // Public read-only property

    void Start()
    {
        // Obține materialul asociat obiectului
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
        else
        {
            Debug.LogError("Renderer component is missing on this GameObject.", this);
        }

        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned in the script.", this);
        }

        timer = countdownTime;

        // Începe countdown-ul
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            float fillAmount = Mathf.Clamp01(timer / countdownTime);

            if (material != null)
            {
                // Setează FillAmount pe material
                material.SetFloat("_FillAmount", fillAmount);
            }

            yield return null; // Așteaptă până la următorul frame
        }

        // Countdown terminat
        isCountdownFinished = true;

        // Apelează metoda Explode
        Explode();
    }

    public void Explode()
    {
        //scade viata
        FindAnyObjectByType<BeerBarScript>().SetCondition(2, true);
        // Redă sunetul de explozie

        if (bombExplosion != null)
        {
            // Folosește AudioManager pentru a reda audio-ul
            AudioManager.Instance.PlayAudio(bombExplosion);
        }


        // Distruge obiectul țintă sau obiectul curent
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
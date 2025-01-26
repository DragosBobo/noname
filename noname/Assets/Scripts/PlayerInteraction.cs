using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject playerMug; // Halba jucătorului
    private BarLogic barManager;

    void Start()
    {
        barManager = Object.FindAnyObjectByType<BarLogic>();
        playerMug.SetActive(false); // Halba jucătorului începe dezactivată
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar"))
        {
            // Jucătorul preia o halbă de pe bar
            if (!playerMug.activeSelf)
            {
                GameObject mugFromBar = barManager.GetRandomMug();
                if (mugFromBar != null)
                {
                    playerMug.SetActive(true);
                }
            }
        }
        else if (other.CompareTag("Client"))
        {
            // Jucătorul livrează halba clientului
            if (playerMug.activeSelf)
            {
                playerMug.SetActive(false);
                barManager.PlayerReturnedMug(); // Anunță că jucătorul nu mai are halba

                // Redă sunet și dezactivează clientul
                AudioSource audioSource = other.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
                //creste viata playerului 
                FindAnyObjectByType<BeerBarScript>().SetCondition(1, true);
                // Dezactivează clientul
                other.gameObject.SetActive(false);
            }
        }
    }
}
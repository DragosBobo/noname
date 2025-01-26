using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Pentru a folosi SceneManager
using System.Collections;

public class BeerBarScript : MonoBehaviour
{
    public UnityEngine.UI.Image fillImage; // Imaginea nivelului nivelului paharului

    // Creșterea și scăderea bruscă a valorii
    public float increaseAmount = 0.2f; // Cât crește nivelul
    public float decreaseAmount = 0.1f; // Cât scade nivelul

    public float permanentDecreaseRate = 0.05f; // Rata de scădere constantă pe secundă

    private bool condition1 = false; // Prima condiție (crește nivelul)
    private bool condition2 = false; // A doua condiție (scade nivelul)

    private int beerCount = 0; // Numărul de beri băute
    private bool canDrink = true; // Dacă jucătorul poate bea (tasta E activă)
    private float cooldownTime = 3f; // Timpul de blocare după a treia bere
    private float inactivityTimeLimit = 5f; // Timpul de inactivitate (5 secunde)
    private float lastDrinkTime; // Timpul ultimei băuturi

    public GameObject playerMug; // Halba jucătorului
    private BarLogic barManager;

    void Start()
    {
        barManager = Object.FindAnyObjectByType<BarLogic>();
        playerMug.SetActive(false); // Halba jucătorului începe dezactivată
    }

    private void Update()
    {
        // Scădere constantă
        DecreasePermanently();

        if (condition1)
        {
            IncreaseFill(); // Crește nivelul
            condition1 = false; // Resetează condiția
        }

        if (condition2)
        {
            DecreaseFill(); // Scade nivelul
            condition2 = false; // Resetează condiția
        }

        // Apasă E pentru a bea o bere, doar dacă playerMug este activ
        if (Input.GetKeyDown(KeyCode.E) && canDrink && playerMug.activeSelf)
        {
            DrinkBeer();
            lastDrinkTime = Time.time; // Resetăm timpul ultimei băuturi
            playerMug.SetActive(false); // Dezactivează halba
        }

        // Verificăm dacă au trecut 5 secunde fără apăsarea tastei E
        if (Time.time - lastDrinkTime > inactivityTimeLimit)
        {
            ResetBeerState(); // Resetăm starea dacă au trecut 5 secunde
        }

        // Verifică dacă nivelul barei a ajuns la 0 și încarcă scena de final
        if (fillImage.fillAmount <= 0)
        {
            LoadEndScene(); // Apelăm funcția care încarcă scena finală
        }
    }

    // Metoda care crește nivelul paharului
    private void IncreaseFill()
    {
        if (fillImage == null) return;

        fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount + increaseAmount, 0, 1);
    }

    // Metoda care scade nivelul paharului
    private void DecreaseFill()
    {
        if (fillImage == null) return;

        fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount - decreaseAmount, 0, 1);
    }

    // Metoda care scade nivelul constant
    private void DecreasePermanently()
    {
        if (fillImage == null) return;

        fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount - permanentDecreaseRate * Time.deltaTime, 0, 1);
    }

    // Metoda care simulează băutul unei beri
    private void DrinkBeer()
    {
        beerCount++;
        GameManager.Instance.BeersDrunk();

        if (beerCount == 1)
        {
            // Crește viața cu 0.5 la prima bere
            if (fillImage != null)
            {
                fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount + 0.5f, 0, 1);
            }
        }
        else if (beerCount == 2)
        {
            // Crește viața cu 0.2 la a doua bere
            if (fillImage != null)
            {
                fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount + 0.2f, 0, 1);
            }
        }
        else if (beerCount == 3)
        {
            // Blochează tasta E pentru 3 secunde după a treia bere
            canDrink = false;
            StartCoroutine(UnlockDrinkButton()); // Activează coroutine care va debloca tasta E după 3 secunde
        }

        // Resetează canDrink pentru a preveni apăsarea repetată
        if (beerCount < 3)
        {
            canDrink = false;
            Invoke("ResetDrinkStatus", 1f); // Permite să bei iar după 1 secundă
        }
    }

    // Resetarea stării de băut
    private void ResetDrinkStatus()
    {
        canDrink = true;
    }

    // Coroutine care deblochează tasta E după 3 secunde
    private IEnumerator UnlockDrinkButton()
    {
        yield return new WaitForSeconds(cooldownTime); // Așteaptă 3 secunde
        canDrink = true; // Permite apăsarea tastei E din nou
        beerCount = 0; // Resetează contorul de beri băute
    }

    // Resetarea stării de bere și permiterea de a bea după 5 secunde de inactivitate
    private void ResetBeerState()
    {
        beerCount = 0; // Resetează contorul de beri
        canDrink = true; // Permite din nou apăsarea tastei E
        lastDrinkTime = Time.time; // Resetează timpul ultimei băuturi pentru a evita resetări repetate
    }

    // Setează condițiile din alte scripturi
    public void SetCondition(int conditionIndex, bool state)
    {
        if (conditionIndex == 1) condition1 = state;
        if (conditionIndex == 2) condition2 = state;
    }

    // Funcția care încarcă scena de final
    private void LoadEndScene()
    {
        GameManager.Instance.StopPlaying();
        SceneManager.LoadScene("LevelScene"); // Înlocuiește "EndScene" cu numele real al scenei tale finale
    }
}

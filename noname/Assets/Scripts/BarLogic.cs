using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class BarLogic : MonoBehaviour
{
    public GameObject[] beerMugs; // Array-ul cu halbele de pe bar
    private float timer = 0f;
    public float switchInterval = 3f; // Intervalul de schimbare aleatorie a halbelor
    public bool playerHasMug = false; // Indicator dacă jucătorul are o halbă

    void Start()
    {
        ResetBeerMugs();
    }

    void Update()
    {
        if (playerHasMug) return; // Dacă jucătorul are o halbă, opriți logica de schimbare

        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            SwitchBeerMugs();
            timer = 0f;
        }
    }

    // Activează toate halbele inițial
    public void ResetBeerMugs()
    {
        foreach (var mug in beerMugs)
        {
            if (!mug.activeSelf)
                mug.SetActive(true); // Asigură-te că toate halbele sunt active
        }
    }

    // Activează o halbă dacă este inactivă
    public void SwitchBeerMugs()
    {
        foreach (var mug in beerMugs)
        {
            if (!mug.activeSelf) // Caută o halbă inactivă
            {
                mug.SetActive(true); // Activează halba
                break; // Activează doar una pe rând
            }
        }
    }

    // Returnează o halbă activă și o dezactivează (preluată de jucător)
    public GameObject GetRandomMug()
    {
        foreach (var mug in beerMugs)
        {
            if (mug.activeSelf)
            {
                mug.SetActive(false); // Dezactivează halba selectată
                playerHasMug = true; // Marchează că jucătorul are o halbă
                return mug;
            }
        }
        return null;
    }

    // Resetează statusul când jucătorul returnează halba
    public void PlayerReturnedMug()
    {
        playerHasMug = false; // Jucătorul nu mai are o halbă
        ResetBeerMugs(); // Asigură-te că toate halbele sunt active
    }
}

using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class BeerBarScript : MonoBehaviour
{
    public UnityEngine.UI.Image fillImage; // Imaginea nivelului paharului

    // Creșterea și scăderea bruscă a valorii
    public float increaseAmount = 0.2f; // Cât crește nivelul
    public float decreaseAmount = 0.1f; // Cât scade nivelul

    public float permanentDecreaseRate = 0.05f; // Rata de scădere constantă pe secundă

    private bool condition1 = false; // Prima condiție (crește nivelul)
    private bool condition2 = false; // A doua condiție (scade nivelul)

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

    // Setează condițiile din alte scripturi
    public void SetCondition(int conditionIndex, bool state)
    {
        if (conditionIndex == 1) condition1 = state;
        if (conditionIndex == 2) condition2 = state;
    }
}
using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro
using System.Collections;

public class EndScreenManager : MonoBehaviour
{
    // UI Elements
    public GameObject endScreenPanel; // The panel that contains the end screen UI
    public TextMeshProUGUI beersDeliveredText; // TextMeshPro for beers delivered
    public TextMeshProUGUI beersDrunkText;     // TextMeshPro for beers drunk
    public TextMeshProUGUI survivalTimeText;   // TextMeshPro for survival time

  
     // Display the end screen with the stats
    private void ShowEndScreen()
    {
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(true); // Show the end screen panel

            // Update the TextMeshPro UI text fields
            if (beersDeliveredText != null)
            {
                beersDeliveredText.text = "Beers Delivered: " + GameManager.Instance.beersDelivered.ToString();
            }
            if (beersDrunkText != null)
            {
                beersDrunkText.text = "Beers Drunk: " + GameManager.Instance.beersDrunk.ToString();
            }
            if (survivalTimeText != null)
            {
                // Format the survival time into minutes and seconds
                int minutes = (int)(GameManager.Instance.survivedTime / 60);
                int seconds = (int)(GameManager.Instance.survivedTime % 60);
                survivalTimeText.text = "Survival Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
    }
}
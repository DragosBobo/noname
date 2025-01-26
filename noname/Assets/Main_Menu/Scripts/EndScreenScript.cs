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

    // Game Stats
    private int beersDelivered = 0;   // Number of beers delivered
    private int beersDrunk = 0;       // Number of beers drunk
    private float survivalTime = 0f;  // Time survived in seconds

    // Timer
    private bool isGameRunning = true; // Tracks if the game is still running

    void Start()
    {
        // Hide the end screen at the start
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Update the survival timer while the game is running
        if (isGameRunning)
        {
            survivalTime += Time.deltaTime;
        }
    }

    // Call this method to increment the number of beers delivered
    public void IncrementBeersDelivered()
    {
        beersDelivered++;
    }

    // Call this method to increment the number of beers drunk
    public void IncrementBeersDrunk()
    {
        beersDrunk++;
    }

    // Call this method to end the game and show the end screen
    public void EndGame()
    {
        isGameRunning = false; // Stop the timer
        ShowEndScreen();
    }

    // Display the end screen with the stats
    private void ShowEndScreen()
    {
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(true); // Show the end screen panel

            // Update the TextMeshPro UI text fields
            if (beersDeliveredText != null)
            {
                beersDeliveredText.text = "Beers Delivered: " + beersDelivered.ToString();
            }
            if (beersDrunkText != null)
            {
                beersDrunkText.text = "Beers Drunk: " + beersDrunk.ToString();
            }
            if (survivalTimeText != null)
            {
                // Format the survival time into minutes and seconds
                int minutes = (int)(survivalTime / 60);
                int seconds = (int)(survivalTime % 60);
                survivalTimeText.text = "Survival Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
    }
}
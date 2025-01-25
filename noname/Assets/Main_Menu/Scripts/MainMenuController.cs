using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Button_StartGame()
    {
        Debug.Log("Start Game Button Clicked");
        
        SceneManager.LoadScene(1);
    }

    public void Button_ConfirmQuit()
    {
       Debug.Log("Quit Game Button Clicked");
       
       Application.Quit();
    }
}

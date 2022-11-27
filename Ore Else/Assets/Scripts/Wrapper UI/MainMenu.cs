using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Function to load the main game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    //Function to load the credits scene
    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }

  

    //Function to quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}

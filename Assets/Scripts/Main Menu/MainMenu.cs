using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTest : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level Menu");
    }
    public void GoToSettings() 
    {
        SceneManager.LoadScene("Settings");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame() 
    { 
        Application.Quit();
    }
}

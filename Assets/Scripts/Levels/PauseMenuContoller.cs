using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PauseMenuContoller : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private PlayerController player;
    private bool isPaused = false;
    public bool IsPaused() 
    {
        return isPaused;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                isPaused = false;
                MainMenuPanel.SetActive(isPaused);
                Time.timeScale = 1f;
            }
            else 
            {
                if (!player.isFacingRight) 
                {
                    Vector3 _ = transform.position;
                    _.x *= -1f;
                    transform.position = _;
                }
                isPaused = true;
                MainMenuPanel.SetActive(isPaused);
                Time.timeScale = 0f;
            }
        }
    }
    public void ResumeGame() 
    {
        isPaused = false;
        MainMenuPanel.SetActive(isPaused);
        Time.timeScale = 1f;
    }
    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void ExitGame() 
    { 
        Application.Quit();
    }
}

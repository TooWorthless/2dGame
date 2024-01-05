using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PauseMenuContoller : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    List<GameObject> buttonList = new List<GameObject>();

    private bool isPaused = false;
    private bool isFlipped = false;
    private void Start()
    {
        buttonList.Add(button1);
        buttonList.Add(button2);
        buttonList.Add(button3);
    }
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
                if (isFlipped != !player.isFacingRight) 
                {
                    isFlipped = !player.isFacingRight;
                    Debug.Log("Is flipped:" + isFlipped);
                    foreach (GameObject button in buttonList)
                    {
                        Vector3 localScale = button.transform.localScale;
                        localScale.x *= -1f;
                        button.transform.localScale = localScale;
                    }

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

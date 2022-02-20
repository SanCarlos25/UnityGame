using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Function pauses the game
    public void PauseGame()
    {
        // activates pause menu UI
        pauseMenuUI.SetActive(true);
        // "pauses" the game by setting the time to 0
        Time.timeScale = 0f;
        // updates GameIsPaused function to true
        GameIsPaused = true;
    }

    // Function unpauses the game
    public void ResumeGame()
    {
        // deactivates pause menu UI
        pauseMenuUI.SetActive(false);
        // "unpauses the game" by setting time back to normal
        Time.timeScale = 1f;
        // updates the GameIsPaused function to true
        GameIsPaused = false;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void OpenSettings()
    {
        if (GameIsPaused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        
    }

    public void CloseSettings()
    {
        if (GameIsPaused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    // pauses the game
    public void PauseGame()
    {
        // activates pause menu UI
        pauseMenuUI.SetActive(true);
        // "pauses" the game by setting the time to 0
        Time.timeScale = 0f;
        // updates GameIsPaused function to true
        GameIsPaused = true;
    }

    // unpauses the game
    public void ResumeGame()
    {
        // deactivates pause menu UI
        pauseMenuUI.SetActive(false);
        // "unpauses the game" by setting time back to normal
        Time.timeScale = 1f;
        // updates the GameIsPaused value to true
        GameIsPaused = false;
    }

    // returns to main menu
    public void BackToMainMenu()
    {
        // resumes the game by setting time back to normal
        Time.timeScale = 1f;
        // updates GameIsPaused value to true
        GameIsPaused = false;
        // Switches Scenes using LoadScene() buy getting the current build index of the
        // game scene (index 2) and subracting in by 2 to get to the main menu (index 0)
        FirstLevel.ChestClick = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }

    // opens the settings 
    public void OpenSettings()
    {
        // handles opening setting when in the game scene
        if (GameIsPaused)
        {
            // Switches Scenes using LoadScene() buy getting the current build index of the
            // game scene (index 2) and adding 1 to get the settings scene (index 3)
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            pauseMenuUI.SetActive(false);
            settingsMenuUI.SetActive(true);
        }
        // handles opening settings when in the main menu scene
        else
        {
            // Switches Scenes using LoadScene() buy getting the current build index of the
            // main menu scene (index 0) and adding 3 to get the settings scene (index 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        
    }

    // closes the settings
    public void CloseSettings()
    {
        // handles closing the settings when playing the game
        if (GameIsPaused)
        {
            // Switches Scenes using LoadScene() buy getting the current build index of the
            // settings scene (index 3) and subtracting 1 to get the game scene (index 2)
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            settingsMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            // sets the GameIsPauses values to false
        }
        // handles closing the settings when in the main menu scene
        else
        {
            // Switches Scenes using LoadScene() buy getting the current build index of the
            // settings scene (index 3) and subtracting 3 to get the main menu scene (index 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }

    // restarts the level by reloading the scene
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        FirstLevel.ChestClick = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

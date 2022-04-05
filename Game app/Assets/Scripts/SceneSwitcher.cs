using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // switches scenes to the char se
    public void playGame()
    {
        // Switches Scenes using LoadScene() buy getting the current build index of the
        // main menu scene (index 0) and adding 1 to get to the char select scene (index 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // quits the game
    public void quitGame()
    {
        // just to show the function is working becuase the emulator cant be quit
        Debug.Log("Quit");
        // quits the application
        Application.Quit();
    }


}

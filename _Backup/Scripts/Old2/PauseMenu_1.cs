using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu_1 : MonoBehaviour
{
    public static bool GameIsPaused = false; // public = accessible from other scripts.
                                             // static = we don't want to reference this specific script, 
                                             // we just want to be able to easily check from other scripts whether or not the game is currently paused.

    public GameObject pauseMenuUI;

    LevelChanger_Levels levelsChanger;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume(); // resume play
            }
            else
            {
                Pause(); // freeze time in our game
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Debug.Log("Hide Menu");
    }

    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Debug.Log("Show Menu");
    }

    public void RestartGame()
    {
        /*        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);*/
        FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<LevelChanger_Levels>().FadeToMainMenu();
        // SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

}


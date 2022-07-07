using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; // public = accessible from other scripts.
                                             // static = we don't want to reference this specific script, 
                                             // we just want to be able to easily check from other scripts whether or not the game is currently paused.

    public GameObject pauseMenuUI;
    public GameObject menuButtonUI;
    public GameObject playerButtons;

    TimerScript timerScript;
    MusicManager musicManager;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameObject thisGameSession = GameObject.Find("Gamesession"); // find Gamesession
        timerScript = thisGameSession.GetComponent<TimerScript>(); // reference to timerScript so we can refer to its variables
        timerScript.timerText.text = timerScript.levelTimer.ToString(); // convert to string
        //
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    public void menuButtonRole()
    {
        if (GameIsPaused == false)
        {
            Pause();
        }
        else
        {
            if (GameIsPaused == true)
            {
                Resume();
            }     
        }
        FindObjectOfType<AudioManager>().Play("MenuButtonClick");
    }

    public void Resume()
    {
        playerButtons.SetActive(true);
        pauseMenuUI.SetActive(false);
        menuButtonUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void Pause() // freeze time in our game
    {
        playerButtons.SetActive(false);
        pauseMenuUI.SetActive(true);
        menuButtonUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartGame()
    {
        musicManager.stateSwitch = true;

        FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
        Time.timeScale = 1f;
        GameIsPaused = false;
        //
        timerScript.decimalLevelTimer = 10f;
        timerScript.levelTimer = Mathf.RoundToInt(timerScript.decimalLevelTimer);
        timerScript.timeElapsed = 0;
        timerScript.exitOnTime = false;
        timerScript.startTimer = false;
        timerScript.playerDied = false;
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void ReturnToMainMenu()
    {
        musicManager.stateSwitch = false;
        FindObjectOfType<LevelChanger_Levels>().FadeToMainMenu();
        Time.timeScale = 1f;
        GameIsPaused = false;
        timerScript.startTimer = false;
        timerScript.playerDied = false;
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        if (musicManager.currentSceneIndex >= 3 && musicManager.currentSceneIndex <= 12)
        {
            musicManager.SwapTracks("Theme_1_10", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 13 && musicManager.currentSceneIndex <= 17)
        {
            musicManager.SwapTracks("Theme_11_15", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 18 && musicManager.currentSceneIndex <= 22)
        {
            musicManager.SwapTracks("Theme_16_20", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 23 && musicManager.currentSceneIndex <= 27)
        {
            musicManager.SwapTracks("Theme_21_25", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 28 && musicManager.currentSceneIndex <= 31)
        {
            musicManager.SwapTracks("Theme_26_29", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 32 && musicManager.currentSceneIndex <= 34)
        {
            musicManager.SwapTracks("Theme_30_32", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 35 && musicManager.currentSceneIndex <= 39)
        {
            musicManager.SwapTracks("Theme_33_37", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 40 && musicManager.currentSceneIndex <= 42)
        {
            musicManager.SwapTracks("Theme_38_40", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 43 && musicManager.currentSceneIndex <= 49)
        {
            musicManager.SwapTracks("Theme_41_47", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex >= 50 && musicManager.currentSceneIndex <= 51)
        {
            musicManager.SwapTracks("Theme_48_49", "Theme_Main_Menu");
        }
        else if (musicManager.currentSceneIndex == 52)
        {
            musicManager.SwapTracks("Theme_50", "Theme_Main_Menu");
        }
        else
        {
            musicManager.Play("Theme_Main_Menu");
        }
    }

}
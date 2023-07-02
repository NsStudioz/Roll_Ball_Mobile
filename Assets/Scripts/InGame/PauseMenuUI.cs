using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject controlsUI;

    [Header("Buttons")]
    [SerializeField] private Button pauseGameBtn;
    [SerializeField] private Button resumeGameBtn;
    [SerializeField] private Button RestartLevelBtn;
    [SerializeField] private Button ReturnToMainMenuBtn;

    MusicManager musicManager;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //
        pauseGameBtn.onClick.AddListener(Pause);
        resumeGameBtn.onClick.AddListener(Resume);
        RestartLevelBtn.onClick.AddListener(RestartGame);
        ReturnToMainMenuBtn.onClick.AddListener(ReturnToMainMenu);

        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    private void OnDestroy()
    {
        pauseGameBtn.onClick.RemoveAllListeners();
        resumeGameBtn.onClick.RemoveAllListeners();
        RestartLevelBtn.onClick.RemoveAllListeners();
        ReturnToMainMenuBtn.onClick.RemoveAllListeners();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HidePauseMenu();
    }

    private void StopTimer()
    {
        GameEvents.OnTriggerStopTimer?.Invoke();
    }

    private void Pause() // freeze time in our game
    {
        ShowPauseMenu();
        Time.timeScale = 0f;
        //
        FindObjectOfType<AudioManager>().Play("MenuButtonClick");
    }

    private void Resume()
    {
        HidePauseMenu();
        ResumeGame();
        //
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void ShowPauseMenu()
    {
        controlsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    private void HidePauseMenu()
    {
        controlsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void RestartGame()
    {
        StopTimer();
        ResumeGame();

        musicManager.stateSwitch = true;

        //FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
        //
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        GameEvents.OnRestartLevel?.Invoke(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        StopTimer();
        ResumeGame();

        musicManager.stateSwitch = false;
        //FindObjectOfType<LevelChanger_Levels>().FadeToMainMenu();
        GameEvents.OnReturnToMainMenu?.Invoke();

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


/*public static bool PauseGame = false;     // public = accessible from other scripts.
                                            // static = we don't want to reference this specific script, 
                                            // we just want to be able to easily check from other scripts whether or not the game is currently paused.*/
//Debug.Log("PauseGame = " + PauseGame);

/*    [SerializeField] private GameObject menuButtonUI;
[SerializeField] private GameObject playerButtons;*/

//TimerScript timerScript;

/*        GameObject thisGameSession = GameObject.Find("Gamesession"); // find Gamesession
    timerScript = thisGameSession.GetComponent<TimerScript>(); // reference to timerScript so we can refer to its variables*/
//timerScript.timerText.text = timerScript.levelTimer.ToString(); // convert to string

/*    public void MenuButtonRole()
    {
        if (PauseGame == false)
        {
            Pause();
        }
        else if (PauseGame == true)
        {
            Resume();
        }

        Debug.Log("PauseGame = " + PauseGame);
        FindObjectOfType<AudioManager>().Play("MenuButtonClick");
    }
*/
/*    private void SwitchGameIsPausedState()
    {
        PauseGame = !PauseGame;
    }

    private bool PauseGameState(bool state)
    {
        return PauseGame = state;
    }*/

/*        timerScript.decimalLevelTimer = 10f;
        timerScript.levelTimer = Mathf.RoundToInt(timerScript.decimalLevelTimer);
        timerScript.timeElapsed = 0;
        timerScript.exitOnTime = false;
        timerScript.startTimer = false;
        timerScript.playerDied = false;*/

/*        timerScript.startTimer = false;
        timerScript.playerDied = false;*/
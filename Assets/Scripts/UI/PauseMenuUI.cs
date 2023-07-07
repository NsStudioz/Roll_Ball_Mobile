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

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //
        pauseGameBtn.onClick.AddListener(Pause);
        resumeGameBtn.onClick.AddListener(Resume);
        RestartLevelBtn.onClick.AddListener(RestartLevel);
        ReturnToMainMenuBtn.onClick.AddListener(ReturnToMainMenu);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
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
        PauseGame();
        //
        //PlayAudioClipOnMenuButtonClick();
        TriggerOnPauseEvent();
    }

    private void Resume()
    {
        HidePauseMenu();
        ResumeGame();
        //
        //PlayAudioClipOnButtonClick();
        TriggerOnResumeEvent();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
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

    private void TriggerOnPauseEvent()
    {
        UIEvents.OnPause?.Invoke();
    }

    private void TriggerOnResumeEvent()
    {
        UIEvents.OnResume?.Invoke();
    }

    private void PlayAudioClipOnButtonClick()
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    private void PlayAudioClipOnMenuButtonClick()
    {
        SoundManager.Instance.Play("MenuButtonClick");
    }

    // Button Function
    private void RestartLevel()
    {
        StopTimer();
        ResumeGame();

        TriggerRestartLevelEvent();
    }

    // Button Function
    private void ReturnToMainMenu()
    {
        StopTimer();
        ResumeGame();

        TriggerReturnToMainMenuEvent();
    }

    private void TriggerRestartLevelEvent()
    {
        GameEvents.OnRestartLevel?.Invoke(GameSession.Instance.CurrentSceneIndex);
    }

    private void TriggerReturnToMainMenuEvent()
    {
        GameEvents.OnReturnToMainMenu?.Invoke();
    }
}



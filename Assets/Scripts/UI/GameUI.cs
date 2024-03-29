using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [Header("GameObjects")]
    [SerializeField] private GameTimer gameTimer;

    [Header("Timer Elements")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject OutOfTimeTextObject;

    [Header("Jump Elements")]
    [SerializeField] private TMP_Text jumpsText;

    [Header("Key Elements")]
    [SerializeField] private GameObject keysObjects;
    [SerializeField] private TMP_Text keysText;

    private void OnSceneLoaded(Scene scene, LoadSceneMode Mode)
    {
        if (scene.buildIndex > 2 && scene.buildIndex < 53)
        {
            SetTimerTextVisibility();
            SetKeysObjectsVisibility();
            SyncGameTimerText();
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnEnable()
    {
        GameEvents.OnOutOfTime += ShowTimeOutText;
        GameEvents.OnPlayerJumpsCheck += SyncJumpsText;
        GameEvents.OnKeyCountCheck += SyncKeyCountText;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        GameEvents.OnOutOfTime -= ShowTimeOutText;
        GameEvents.OnPlayerJumpsCheck -= SyncJumpsText;
        GameEvents.OnKeyCountCheck -= SyncKeyCountText;
    }

    void Update() => SyncGameTimerText();


    private void SyncJumpsText(int jumps)
    {
        jumpsText.text = jumps.ToString();
    }

    #region Keys_Texts:

    private void SyncKeyCountText(int keys)
    {

        keysText.text = keys.ToString();
    }

    private void SetKeysObjectsVisibility()
    {
        if(GameSession.Instance.CurrentSceneIndex >= 32)
            keysObjects.SetActive(true);
        else
            keysObjects.SetActive(false);
    }

    #endregion

    #region Timer_Texts:

    private void SyncGameTimerText()
    {
        timerText.text = gameTimer.LevelTimer.ToString();
    }

    private void SetTimerTextVisibility()
    {
        if (GameSession.Instance.EarlyLevels)
            HideTimerTexts();
        else
            ShowTimerText();
    }

    private void ShowTimeOutText() => SetTimerTexts(false, true);

    private void ShowTimerText() => SetTimerTexts(true, false);

    private void HideTimerTexts() => SetTimerTexts(false, false);

    private void SetTimerTexts(bool _timerTextObject, bool _OutOfTimeTextObject)
    {
        timerTextObject.SetActive(_timerTextObject);
        OutOfTimeTextObject.SetActive(_OutOfTimeTextObject);
    }

    #endregion

}



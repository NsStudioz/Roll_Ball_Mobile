using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{

    public static GameUIManager Instance;

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


    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (Instance == null) { Instance = this; } // singleton pattern
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
        }

        DontDestroyOnLoad(gameObject);
    }

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
        PlayerEvents.OnOutOfTime += ShowTimeOutText;
        PlayerEvents.OnPlayerJumpsCheck += SyncJumpsText;
        PlayerEvents.OnKeyCountCheck += SyncKeyCountText;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        PlayerEvents.OnOutOfTime -= ShowTimeOutText;
        PlayerEvents.OnPlayerJumpsCheck -= SyncJumpsText;
        PlayerEvents.OnKeyCountCheck -= SyncKeyCountText;

    }

    void Update()
    {
        SyncGameTimerText();
    }

    private void SyncJumpsText(int jumps)
    {
        jumpsText.text = jumps.ToString();
    }

    private void SyncKeyCountText(int keys)
    {

        keysText.text = keys.ToString();
    }

    private void SetKeysObjectsVisibility()
    {
        if(GameSession.Instance.CurrentSceneIndex > 32)
            keysObjects.SetActive(true);
        else
            keysObjects.SetActive(false);
    }


    #region Timer Texts

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

    private void ShowTimeOutText()
    {
        SetTimerTexts(false, true);
    }

    private void ShowTimerText()
    {
        SetTimerTexts(true, false);
    }

    private void HideTimerTexts()
    {
        SetTimerTexts(false, false);
    }

    private void SetTimerTexts(bool _timerTextObject, bool _OutOfTimeTextObject)
    {
        timerTextObject.SetActive(_timerTextObject);
        OutOfTimeTextObject.SetActive(_OutOfTimeTextObject);
    }

    #endregion

}


//jumpsText.text = GameSession.Instance.PlayerJumps.ToString();
//keysText.text = GameSession.Instance.KeyCount.ToString();
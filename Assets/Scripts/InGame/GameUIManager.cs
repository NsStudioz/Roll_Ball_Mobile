using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{

    public static GameUIManager Instance;

    [Header("GameObjects")]
    [SerializeField] private GameTimer gameTimer;

    [Header("Timer Elements")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject OutOfTimeTextObject;

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

    private void OnEnable()
    {
        PlayerEvents.OnOutOfTime += ShowTimeOutText;
        PlayerEvents.OnLevelLoad += SetTimerTextVisibility;

    }
    private void OnDisable()
    {
        PlayerEvents.OnOutOfTime -= ShowTimeOutText;
        PlayerEvents.OnLevelLoad -= SetTimerTextVisibility;

    }


    void Update()
    {
        SyncGameTimerText();
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

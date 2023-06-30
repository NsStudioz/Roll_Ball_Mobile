using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    [SerializeField] private float decimalTimer = 10f;
    [SerializeField] private int levelTimer;
    [SerializeField] private float resetTimer = 10f;
    [SerializeField] private float resetTimerDelay;

    [SerializeField] private bool startTimer;
    [SerializeField] private bool outOfTime;
    [SerializeField] private bool isOutOfTimeAudioPlayed;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject timeOutTextObject;


    private void OnEnable()
    {
        PlayerEvents.OnTimePickup += AddTimeToTimer;
        PlayerEvents.OnLevelStarted += StartTimer;
        PlayerEvents.OnLevelCompleted += ResetTimer;
        PlayerEvents.OnPlayerDead += ResetTimer;
        PlayerEvents.OnLevelReset += ResetTimer;
    }

    private void OnDisable()
    {
        PlayerEvents.OnTimePickup -= AddTimeToTimer;
        PlayerEvents.OnLevelStarted -= StartTimer;
        PlayerEvents.OnLevelCompleted -= ResetTimer;
        PlayerEvents.OnPlayerDead -= ResetTimer;
        PlayerEvents.OnLevelReset -= ResetTimer;
    }

    void Start()
    {
        DisableTimer();
    }

    void Update()
    {
        if (GameSession.Instance.GetSceneIndex() < 5)
            return;

        if (!startTimer)
            return;

        SyncTimerText();
        decimalTimer -= Time.deltaTime;

        if (decimalTimer < 0)
        {
            SetTimerState(false, true);
            OutOfTime();
        }
    }

    private void DisableTimer() // timer disabled during the first few level.
    {
        if (GameSession.Instance.GetSceneIndex() < 5)
        {
            SetTexts(false, false);
            SetTimerState(false, false);
        }
    }

    private void ResetTimer()
    {
        StartCoroutine(ResetTimerCoRoutine());
    }

    private void ResetTimerSettings()
    {
        isOutOfTimeAudioPlayed = false;
        decimalTimer = resetTimer;
        SyncTimerText();
    }

    private IEnumerator ResetTimerCoRoutine()
    {
        SetTimerState(false, false);
        SetTexts(true, false);
        yield return new WaitForSeconds(resetTimerDelay);
        ResetTimerSettings();
    }

    public bool GetOutOfTime()
    {
        return outOfTime;
    }

    private void OutOfTime()
    {
        if (outOfTime)
        {
            PlayerEvents.OnOutOfTime?.Invoke();
            SetTexts(false, true);
            PlayOutOfTimeAudio();
        }
    }


    private void SetTexts(bool _timerTextObject, bool _timeOutTextObject)
    {
        timerTextObject.SetActive(_timerTextObject);
        timeOutTextObject.SetActive(_timeOutTextObject);
    }

    private void SyncTimerText()
    {
        levelTimer = Mathf.RoundToInt(decimalTimer);
        timerText.text = levelTimer.ToString();
    }

    private void StartTimer()
    {
        startTimer = true;
    }

    private void SetTimerState(bool _startTimer, bool _outOfTime)
    {
        startTimer = _startTimer;
        outOfTime = _outOfTime;
    }

    // Time Pickups
    private void AddTimeToTimer(float time)
    {
        decimalTimer += time;
    }

    // use bool & event to trigger once.
    private void PlayOutOfTimeAudio()
    {
        if (!isOutOfTimeAudioPlayed)
        {
            AudioManager.Instance.Play("PlayerDeath");
            isOutOfTimeAudioPlayed = true;
        }
    }

}


//decimalTimer = Time.unscaledDeltaTime;
//[SerializeField] private int timeElapsed;
//[SerializeField] private int timeElapsedThreshold;
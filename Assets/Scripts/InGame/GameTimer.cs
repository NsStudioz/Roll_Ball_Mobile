using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public int LevelTimer { get; private set; }

    [SerializeField] private float decimalTimer = 0;

    [SerializeField] private float resetTimer = 10f;

    [SerializeField] private bool startTimer;
    [SerializeField] private bool isOutOfTimeAudioPlayed;


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimer();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //
        GameEvents.OnLevelStarted += StartTimer;
        GameEvents.OnTriggerStopTimer += StopTimer;
        GameEvents.OnTimePickup += AddTimeToTimer;    
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        GameEvents.OnLevelStarted -= StartTimer;
        GameEvents.OnTriggerStopTimer -= StopTimer;
        GameEvents.OnTimePickup -= AddTimeToTimer;
    }

    void Update()
    {

        if (GameSession.Instance.EarlyLevels || !startTimer)
            return;

        if (decimalTimer > 0)
        {
            decimalTimer -= Time.deltaTime;
            LevelTimer = Mathf.RoundToInt(decimalTimer);
        }
        else // decimalTimer < 0
        {
            StopTimer();
            OutOfTime();
        }
    }

    private void ResetTimer()
    {
        decimalTimer = resetTimer;
        LevelTimer = Mathf.RoundToInt(decimalTimer);
        isOutOfTimeAudioPlayed = false;
    }

    private void OutOfTime()
    {
        GameEvents.OnOutOfTime?.Invoke();
        PlayOutOfTimeAudio();
    }

    private void StartTimer()
    {
        SetTimerState(true);
    }

    private void StopTimer()
    {
        SetTimerState(false);
    }

    private void SetTimerState(bool _startTimer)
    {
        startTimer = _startTimer;
    }

    // Time Pickups
    private void AddTimeToTimer(float time)
    {
        decimalTimer += time;
    }

    // use bool & event to play once.
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

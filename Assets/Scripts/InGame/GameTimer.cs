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



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetTimer();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //
        GameEvents.OnLevelStarted += OnLevelStartedInvoked_StartTimer;
        GameEvents.OnTriggerStopTimer += OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer;
        GameEvents.OnPlayerDead += OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer;
        GameEvents.OnTimePickup += OnTimePickupInvoked_AddTimeToTimer;    
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        GameEvents.OnLevelStarted -= OnLevelStartedInvoked_StartTimer;
        GameEvents.OnTriggerStopTimer -= OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer;
        GameEvents.OnPlayerDead -= OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer;
        GameEvents.OnTimePickup -= OnTimePickupInvoked_AddTimeToTimer;
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
            OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer();
            OutOfTime();
        }
    }

    private void ResetTimer()
    {
        decimalTimer = resetTimer;
        LevelTimer = Mathf.RoundToInt(decimalTimer);
    }

    private void OutOfTime() => TriggerOnOutOfTimeEvent();

    private void TriggerOnOutOfTimeEvent()
    {
        GameEvents.OnOutOfTime?.Invoke();
    }

    private void OnLevelStartedInvoked_StartTimer() => SetTimerState(true);

    private void OnTriggerStopTimerOrOnPlayerDeadInvoked_StopTimer() => SetTimerState(false);

    private void SetTimerState(bool _startTimer)
    {
        startTimer = _startTimer;
    }

    // Time Pickups
    private void OnTimePickupInvoked_AddTimeToTimer(float time)
    {
        decimalTimer += time;
    }

}

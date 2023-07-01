using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public int LevelTimer { get; private set; }

    [SerializeField] private float decimalTimer = 0;

    [SerializeField] private float resetTimer = 10f;

    [SerializeField] private bool startTimer;
    [SerializeField] private bool isOutOfTimeAudioPlayed;



    private void OnEnable()
    {
        PlayerEvents.OnLevelLoad += ResetTimer;
        PlayerEvents.OnLevelStarted += StartTimer;
        PlayerEvents.OnTriggerStopTimer += StopTimer;
        PlayerEvents.OnTimePickup += AddTimeToTimer;    
    }

    private void OnDisable()
    {
        PlayerEvents.OnLevelLoad -= ResetTimer;
        PlayerEvents.OnLevelStarted -= StartTimer;
        PlayerEvents.OnTriggerStopTimer -= StopTimer;
        PlayerEvents.OnTimePickup -= AddTimeToTimer;
    }

    void Update()
    {

        if (!GameSession.Instance.EarlyLevels || !startTimer)
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
        isOutOfTimeAudioPlayed = false;
    }

    private void OutOfTime()
    {
        PlayerEvents.OnOutOfTime?.Invoke();
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

//[SerializeField] private float resetTimerDelay;

/*        if (decimalTimer < 0)
        {
            SetTimerState(false);
            OutOfTime();
        }*/


/*PlayerEvents.OnLevelCompleted += StopTimer;
        PlayerEvents.OnPlayerDead += StopTimer;
        PlayerEvents.OnLevelReset += StopTimer;
        PlayerEvents.OnLevelCompleted -= StopTimer;
        PlayerEvents.OnPlayerDead -= StopTimer;
        PlayerEvents.OnLevelReset -= StopTimer;*/

//StartCoroutine(ResetTimerCoRoutine());

/*    private IEnumerator ResetTimerCoRoutine()
    {
        SetTimerState(false);
        isOutOfTimeAudioPlayed = false;
        yield return new WaitForSeconds(resetTimerDelay);
        ResetTimerCalculations();
    }

    private void ResetTimerCalculations()
    {
        decimalTimer = resetTimer;
    }*/


//[SerializeField] private int levelTimer;

/*    public int GetLevelTimer()
    {
        return levelTimer;
    }*/

/*    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject timeOutTextObject;*/

//[SerializeField] private bool outOfTime;

//decimalTimer = Time.unscaledDeltaTime;

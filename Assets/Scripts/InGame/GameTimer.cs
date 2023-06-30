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
    [SerializeField] private bool isOutOfTimeAudioPlayed;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject timeOutTextObject;


    private void OnEnable()
    {
        PlayerEvents.OnLevelLoad += SetTimerToLevel;
        PlayerEvents.OnTimePickup += AddTimeToTimer;
        PlayerEvents.OnLevelStarted += StartTimer;
        PlayerEvents.OnLevelCompleted += ResetTimer;
        PlayerEvents.OnPlayerDead += ResetTimer;
        PlayerEvents.OnLevelReset += ResetTimer;
    }

    private void OnDisable()
    {
        PlayerEvents.OnLevelLoad -= SetTimerToLevel;
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
        if (!startTimer)
            return;

        SyncTimerText();
        decimalTimer -= Time.deltaTime;

        if (decimalTimer < 0)
        {
            SetTexts(false, true);
            SetTimerState(false);
            OutOfTime();
        }
    }

    private void SetTimerToLevel()
    {
        if (GameSession.Instance.GetSceneIndex() > 5)
        {
            SetTexts(true, false);
        }
    }

    // timer disabled during the first few levels.
    private void DisableTimer() 
    {
        if (GameSession.Instance.GetSceneIndex() < 5)
        {
            SetTexts(false, false);
            SetTimerState(false);
        }

        isOutOfTimeAudioPlayed = false;
    }

    private void ResetTimer()
    {
        StartCoroutine(ResetTimerCoRoutine());
    }

    private void ResetTimerSettings()
    {
        decimalTimer = resetTimer;
        SyncTimerText();
    }

    private IEnumerator ResetTimerCoRoutine()
    {
        SetTimerState(false);
        SetTexts(true, false);
        isOutOfTimeAudioPlayed = false;
        yield return new WaitForSeconds(resetTimerDelay);
        ResetTimerSettings();
    }

    private void OutOfTime()
    {
        PlayerEvents.OnOutOfTime?.Invoke();
        SetTexts(false, true);
        PlayOutOfTimeAudio();

/*        if (outOfTime)
        {
            PlayerEvents.OnOutOfTime?.Invoke();
            SetTexts(false, true);
            PlayOutOfTimeAudio();
        }*/
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

    private void SetTimerState(bool _startTimer)
    {
        startTimer = _startTimer;
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

//[SerializeField] private bool outOfTime;

//decimalTimer = Time.unscaledDeltaTime;
//[SerializeField] private int timeElapsed;
//[SerializeField] private int timeElapsedThreshold;




/*    public bool GetOutOfTime()
    {
        return outOfTime;
    }*/



/*    private void SetTimerStateOld(bool _startTimer, bool _outOfTime)
    {
        startTimer = _startTimer;
        outOfTime = _outOfTime;
    }*/
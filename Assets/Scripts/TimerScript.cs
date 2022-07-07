using System.Collections;
using UnityEngine;
/*using UnityEngine.UI;*/
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public float decimalLevelTimer = 10f;
    public int levelTimer;
    public int sceneIndex = 1;
    //
    public float timeElapsed = 0f;
    public float delayTime = 2f;
    public float delayThreshold = 2f;
    //
    public bool startTimer;
    public bool exitOnTime = false;
    public bool timesUp = false;
    public bool playerDied = false;
    //
    public TMP_Text timerText;
    public GameObject timeOutText;
    public GameObject timerTextObject;

    AudioSource audioSource;
    public AudioClip timeOutClip;
    public bool isTimeOutPlayed;


    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        if (sceneIndex < 5)
        {
            timeOutText.SetActive(false);
            timerTextObject.SetActive(false);
            startTimer = false;
        }
        audioSource = GetComponent<AudioSource>();
        timerText.text = levelTimer.ToString();
    }

    void Update()
    {
        levelTimer = Mathf.RoundToInt(decimalLevelTimer);
        timerText.text = levelTimer.ToString();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //
        if (sceneIndex > 5)
        {
            if(startTimer == true)
            {
                decimalLevelTimer -= Time.deltaTime;
            }
            else
            {
                return;
            }

            if (levelTimer < 0)
            {
                timesUp = true;
                timerTextObject.SetActive(false);
                if (timesUp)
                {
                    StartCoroutine(ResetLevelOnTimeOut());
                }  
            }

            if (exitOnTime == true)
            {
                StartCoroutine(ResetOnNextLevel());
            }

            if (playerDied == true)
            {
                StartCoroutine(OnDeathSequence());
            }
        }      
    }

    IEnumerator ResetLevelOnTimeOut()
    {
        timeElapsed += Time.deltaTime;
        timeOutText.SetActive(true);
        yield return new WaitForSeconds(2);
        if (timeElapsed > delayThreshold)
        {
            StartCoroutine(ResetLevel()); 
        }
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(0);
        FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
        timeElapsed = 0f;
        startTimer = false; 
    }

    IEnumerator ResetOnNextLevel()
    {
        yield return new WaitForSeconds(0);
        timeElapsed = 0f;
        exitOnTime = false;
        startTimer = false;
    }

    IEnumerator OnDeathSequence()
    {
        startTimer = false;
        yield return new WaitForSeconds(1);
        timeElapsed = 0f;
    }

    public void AddTime(float timePickupsToAdd)
    {
        decimalLevelTimer += timePickupsToAdd;
    }

    public void PlayTimeOutClip()
    {
        if (!isTimeOutPlayed)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            isTimeOutPlayed = true;
        }
    }
}

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger_Levels : MonoBehaviour
{

    TimerScript timerScript;
    MusicManager musicManager;
    //
    public Animator animator; // animator reference so we will be able to use its attributes.
    //
    private int levelToLoad;
    public int currentSceneIndex;
    //private int[] triggerValues = {12, 22, 32, 42, 52};
    private int[] musicTriggerValues = { 3, 13, 18, 23, 28, 32, 35, 40, 43, 50, 52 };


    void Start()
    {
        GameObject thisGameSession = GameObject.Find("Gamesession");
        timerScript = thisGameSession.GetComponent<TimerScript>();
        //
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToCurrentLevel()
    {
        musicManager.stateSwitch = true;
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToMainMenu()
    {
        FadeToHomeLevel();
        // comparing currentSceneIndex values with triggerValues.
/*        if (triggerValues.Contains(currentSceneIndex)) 
        {
            Debug.Log("Ad has started");
            AdManager.Instance.ShowAd(this);
        }*/
    }

    public void FadeToLevel (int currentLevelIndex) // stores a variable of type int, called currentLevelIndex
    {
        levelToLoad = currentLevelIndex; // store the new value of '1' into 'levelToLoad'
        animator.SetTrigger("FadeOut"); // run animation
    }

    public void FadeToHomeLevel() // stores a variable of type int, called currentLevelIndex
    {
        levelToLoad = 1; // store the new value of '1' into 'levelToLoad'
        animator.SetTrigger("FadeOut"); // run animation
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); // load the scene with the value index of 'X' (levelToLoad)
        timerScript.decimalLevelTimer = 10f;
        timerScript.timeElapsed = 0f;
        timerScript.timesUp = false;
        timerScript.timeOutText.SetActive(false);
        // timerScript.timerTextObject.SetActive(true);

        if (levelToLoad > 5)
        {
            timerScript.timerTextObject.SetActive(true);
        }

/*        if (musicTriggerValues.Contains(levelToLoad))
        {
            musicManager.stateSwitch = false;
        }*/

        if (!musicManager.stateSwitch)
        {
            switch (levelToLoad) // 
            {
                case 3:
                    musicManager.SwapTracks("Theme_Main_Menu", "Theme_1_10");
                    break;
                case 13:
                    musicManager.SwapTracks("Theme_1_10", "Theme_11_15");
                    break;
                case 18:
                    musicManager.SwapTracks("Theme_11_15", "Theme_16_20");
                    break;
                case 23:
                    musicManager.SwapTracks("Theme_16_20", "Theme_21_25");
                    break;
                case 28:
                    musicManager.SwapTracks("Theme_21_25", "Theme_26_29");
                    break;
                case 32:
                    musicManager.SwapTracks("Theme_26_29", "Theme_30_32");
                    break;
                case 35:
                    musicManager.SwapTracks("Theme_30_32", "Theme_33_37");
                    break;
                case 40:
                    musicManager.SwapTracks("Theme_33_37", "Theme_38_40");
                    break;
                case 43:
                    musicManager.SwapTracks("Theme_38_40", "Theme_41_47");
                    break;
                case 50:
                    musicManager.SwapTracks("Theme_41_47", "Theme_48_49");
                    break;
                case 52:
                    musicManager.SwapTracks("Theme_48_49", "Theme_50");
                    break;
                default:
                    Debug.Log("No Default Music found or necessary");
                    break;
            }
        }
    }

/*    internal void ContinueGame()
    {
        Debug.Log("Closing Ad");
    }*/

}




using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger_Levels : MonoBehaviour
{

    MusicManager musicManager;
    //
    public Animator animator;
    //
    private int levelToLoad;


    void Start()
    {
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToCurrentLevel()
    {
        //musicManager.stateSwitch = true;
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToMainMenu()
    {
        FadeToHomeLevel();
    }

    private void FadeToLevel (int currentLevelIndex)
    {
        levelToLoad = currentLevelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToHomeLevel()
    {
        levelToLoad = 1;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); // load the scene with the value index of 'X' (levelToLoad)

        // Music Manager Mechanic:
/*        if (!musicManager.stateSwitch)
        {
            switch (levelToLoad) 
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
                    break;
            }
        }*/
    }
}


//[SerializeField] int currentSceneIndex;
//TimerScript timerScript;

/*        GameObject thisGameSession = GameObject.Find("Gamesession");
    timerScript = thisGameSession.GetComponent<TimerScript>();*/

/*    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }*/

//PlayerEvents.OnLevelLoad?.Invoke();

/*        if (levelToLoad > 5)
        {
            timerScript.timerTextObject.SetActive(true);
        }*/


/*        timerScript.decimalLevelTimer = 10f;
        timerScript.timeElapsed = 0f;
        timerScript.timesUp = false;
        timerScript.timeOutText.SetActive(false);*/




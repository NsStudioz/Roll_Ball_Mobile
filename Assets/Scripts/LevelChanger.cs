using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    TimerScript timerScript;
    MusicManager musicManager;

    public Animator animator; // animator reference so we will be able to use its attributes.
    private int levelToLoad;

    void Start()
    {
        GameObject thisGameSession = GameObject.Find("Gamesession");
        timerScript = thisGameSession.GetComponent<TimerScript>();

        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }


    void Update()
    {
/*        if (Input.GetMouseButtonDown(1)) // if clicked left mouse button
        {
            FadeToNextLevel(); // when we call this method and pass in the value of '1' (the index)
        }*/
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToCurrentLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToLevel (int currentLevelIndex) // stores a variable of type int, called currentLevelIndex
    {
        levelToLoad = currentLevelIndex; // store the new value of '1' into 'levelToLoad'

        animator.SetTrigger("FadeOut"); // run animation

        FindObjectOfType<AudioManager>().Play("LevelChoosed");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); // load the scene with the value index of '1' (levelToLoad)

        if (levelToLoad >= 3 && levelToLoad <= 12)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_1_10");
        }
        else if (levelToLoad >= 13 && levelToLoad <= 17)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_11_15");
        }
        else if (levelToLoad >= 18 && levelToLoad <= 22)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_16_20");
        }
        else if (levelToLoad >= 23 && levelToLoad <= 27)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_21_25");
        }
        else if (levelToLoad >= 28 && levelToLoad <= 31)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_26_29");
        }
        else if (levelToLoad >= 32 && levelToLoad <= 34)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_30_32");
        }
        else if (levelToLoad >= 35 && levelToLoad <= 39)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_33_37");
        }
        else if (levelToLoad >= 40 && levelToLoad <= 42)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_38_40");
        }
        else if (levelToLoad >= 43 && levelToLoad <= 49)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_41_47");
        }
        else if (levelToLoad >= 50 && levelToLoad <= 51)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_48_49");
        }
        else if (levelToLoad == 52)
        {
            musicManager.SwapTracks("Theme_Main_Menu", "Theme_50");
        }
        else
        {
            Debug.Log("Something went wrong, please check!");
            //musicManager.Play("Theme_Main_Menu");
        }

        if (levelToLoad > 5)
        {
            timerScript.timerTextObject.SetActive(true);
        }
    }

}

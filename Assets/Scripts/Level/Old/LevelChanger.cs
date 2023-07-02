using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    MusicManager musicManager;

    public Animator animator;
    private int levelToLoad;

    void Start()
    {
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    public void FadeToLevel (int currentLevelIndex)
    {
        levelToLoad = currentLevelIndex; 

        animator.SetTrigger("FadeOut"); 

        FindObjectOfType<AudioManager>().Play("LevelChoosed");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);

        // Music Manager Mechanic:
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
    }

}

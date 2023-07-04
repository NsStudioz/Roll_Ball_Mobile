using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{

    private string player = "Player";
    private int nextSceneLoad;

    MusicManager musicManager;

    private int[] musicTriggerValues = { 12, 17, 22, 27, 31, 34, 39, 42, 49, 51 };

    void Start()
    {
        nextSceneLoad = GameSession.Instance.CurrentSceneIndex + 1;
        //
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.OnTriggerStopTimer?.Invoke();
        AudioManager.Instance.Play("LevelCompleted");

        if (other.CompareTag(player))
            CheckLevelProgress();

        if (musicTriggerValues.Contains(GameSession.Instance.CurrentSceneIndex))
            musicManager.stateSwitch = false;

        if(GameSession.Instance.CurrentSceneIndex == 52)
           musicManager.SwapTracks("Theme_50", "Theme_Main_Menu");
    }

    private void CheckLevelProgress()
    {
        if (GameSession.Instance.CurrentSceneIndex == 52)
            GameEvents.OnReturnToMainMenu?.Invoke();
        else
        {
            GameEvents.OnLevelCompleted?.Invoke();   
            SaveLevelProgress();
        }
    }

    // Setting Int for Index
    private void SaveLevelProgress()
    {  
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")) 
            PlayerPrefs.SetInt("levelAt", nextSceneLoad); 
    }

}


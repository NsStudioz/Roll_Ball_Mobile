using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    MusicManager musicManager;

    private int[] musicTriggerValues = { 12, 17, 22, 27, 31, 34, 39, 42, 49, 51 };

    void Start()
    {
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        GameEvents.OnLevelCompleted?.Invoke();

        if (musicTriggerValues.Contains(GameSession.Instance.CurrentSceneIndex))
        {
            musicManager.stateSwitch = false;
        }
        
        if(GameSession.Instance.CurrentSceneIndex == 52)
        {
            musicManager.SwapTracks("Theme_50", "Theme_Main_Menu");
        }
    }
}



//TimerScript timerScript;
//[SerializeField] int currentSceneIndex;

/*        GameObject thisGameSession = GameObject.Find("Gamesession");
        timerScript = thisGameSession.GetComponent<TimerScript>();*/



//currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//timerScript.startTimer = false;
